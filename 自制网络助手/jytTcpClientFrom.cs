using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 自制网络助手
{
    public partial class jytTcpClientFrom : Form
    {
        public jytTcpClientFrom()
        {
            //设置 线程可以 操作主线程UI控件  
            /*
             在多线程程序中,新创建的线程不能访问UI线程创建的窗口控件,

            这个时候如果你想要访问窗口的控件,那么你可以将窗口构造函数

            中的CheckForIllegalCrossThreadCalls设置为false.这是线程就

            能安全的访问窗体控件了.
             */
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        //创建 循环发送线程 懒得起名字
        Thread thread;


        //创建一个各个通信方式，存放内容的中转
        JytHttpReturnValue jythttpReturnValue = new JytHttpReturnValue();
        //右键文本框 点击清空
        private void jytOutTxtClear_Click(object sender, EventArgs e)
        {
            jyttxtData.Text = "";
        }
        // jytMenu菜单控件的 添加按钮 
        // 右键 右侧datagridview jytCMD数据区 点击添加按钮
        private void MS_Add_Click(object sender, EventArgs e)
        {
            // jytMenu菜单控件的 添加按钮 
            // 右键 右侧datagridview jytCMD数据区 点击添加按钮
            jytAddCmdTxts f2 = new jytAddCmdTxts("");
            //判断是否点击的 是 确定
            if (f2.ShowDialog() == DialogResult.OK)
            {
                //jytCMD 控件添加一行 获取这行的下标 然后设置 数据到当前行
                int index = this.jytCMD.Rows.Add();
                this.jytCMD.Rows[index].Cells[0].Value = false;
                // f2.TextBoxValue 获取 弹出窗口文本框 输入的内容 （文本框内容保存在TextBoxValue中）
                this.jytCMD.Rows[index].Cells[1].Value = f2.TextBoxValue;
                this.jytCMD.Rows[index].Cells[2].Value = "发送";
                //关闭窗口
                f2.Close();
            }
        }
        //jytCMD 数据表控件右键 点击修改功能
        private void MS_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                //调用 窗口 传入要修改的内容
                jytAddCmdTxts f2 = new jytAddCmdTxts(jytCMD.Rows[jytCMD.CurrentRow.Index].Cells[1].Value.ToString());
                if (f2.ShowDialog() == DialogResult.OK)
                {
                    jytCMD.Rows[jytCMD.CurrentRow.Index].Cells[1].Value = f2.TextBoxValue;

                    f2.Close();
                }
            }
            catch
            {

            }
        }
        //右键 jytCMD数据表格控件 点击删除按钮 删除选中的行
        private void MS_Delete_Click(object sender, EventArgs e)
        {
            this.jytCMD.ClearSelection();
            foreach (DataGridViewRow rowitme in this.jytCMD.Rows)
            {

                if (rowitme.Cells[0].Value.ToString() == "True")
                {
                    this.jytCMD.Rows.Remove(rowitme);

                }
            }
            if (jytCMD.CurrentRow.Index == jytCMD.Rows.Count - 1)
            {
                if (jytCMD.Rows[jytCMD.CurrentRow.Index].Cells[0].Value.ToString() == "True")
                {
                    this.jytCMD.Rows.Remove(jytCMD.Rows[jytCMD.CurrentRow.Index]);

                }

            }
        }
        //无用----将十六进制字符串专场byte数组
        public static byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }
        //点击发送按钮 发送数据
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.jytCmdTxt.Text != "")
                JytSendOut(this.jytCmdTxt.Text);
        }
        //发送单条
        //不知道为啥 单独写了一个这个 忘了 其实 单独写这个方法
        //直接在 调用处 调用SendData就可以 懒得改了
        public void JytSendOut(string data)
        {

            try
            {
                byte[] _jytbyte = JytTransformation(data); //System.Text.Encoding.Default.GetBytes(data);
                
                tcpclient.GetStream().Write(_jytbyte, 0, _jytbyte.Length);
            }
            catch
            {
                MessageBox.Show("发送失败", "错误");
            }
        }
        //通过这个判断 选择的编码格式 下面这四个方法 （有更简单的方法实现这个，--->--->--->--->--->--->--->--->--->--->--->--->--->--->--->--->自行脑补吧）
        int jytCodingtype = 0;
        private void jytHex_CheckedChanged(object sender, EventArgs e)
        {
            if (jytHex.Checked)
            {
                jytCodingtype = 0;
            }
        }
        private void jytASCII_CheckedChanged(object sender, EventArgs e)
        {
            if (jytASCII.Checked)
            {
                jytCodingtype = 1;
            }
        }
        private void jytUTF8_CheckedChanged(object sender, EventArgs e)
        {
            if (jytUTF8.Checked)
            {
                jytCodingtype = 3;
            }
        }
        private void jytGB2312_CheckedChanged(object sender, EventArgs e)
        {
            if (jytGB2312.Checked)
            {
                jytCodingtype = 2;
            }
        }
        //是否启动 连接了
        bool isMonitor = false;

        //循环发送数据按钮  
        private void jytAutoSend_Click(object sender, EventArgs e)
        {
            if (jytAutoSend.Text == "停止发送")
            {
                jytAutoSend.Text = "循环发送";
                thread.Abort();
                //timer1.Enabled = false;
                return;
            }
            if (isMonitor)
            {
                //创建线程
                thread = new Thread(JytCircularTransmission);

                thread.Start();//启动线程

                jytAutoSend.Text = "停止发送";
            }
            else
            {
                thread.Abort();
                jytAutoSend.Text = "循环发送";
                MessageBox.Show("监听未打开", "错误");
            }
        }

        //客户端对象
        TcpClient tcpclient;

        //线程执行的方法 循环发送
        private void JytCircularTransmission()
        {
            try
            {
                //判断是否是连接状态
                if (isMonitor)
                {
                    // 死循环 发送右侧 jytCMD 控件勾选了的 数据
                    while (true)
                    {
                        //实时 获取 要发送的数据是否勾选了 可以在发送的时候 取消勾选 不发送
                        foreach (DataGridViewRow rowitme in this.jytCMD.Rows)
                        {
                            // 判断 复选框是否勾选了 （有其他方法）
                            if (rowitme.Cells[0].Value.ToString() == "True")
                            {
                                //发送一条 等待 设置的间隔事件 单位毫秒
                                Thread.Sleep(int.Parse(jytDelay.Value.ToString()));
                                byte[] _jytbyte = JytTransformation(rowitme.Cells[1].Value.ToString());// System.Text.Encoding.Default.GetBytes(rowitme.Cells[1].Value.ToString());
                                //发送内容
                                tcpclient.GetStream().Write(_jytbyte, 0, _jytbyte.Length);
                            }
                        }
                    }
                }
                else
                {
                    thread.Abort();
                    jytAutoSend.Text = "循环发送";
                }
            }
            catch
            {
                thread.Abort();
                jytAutoSend.Text = "循环发送";
                MessageBox.Show("发送失败", "错误");
            }
        }
        
        //线程 用于监听服务端 发来的消息
        Thread th;

        //点击连接按钮
        private void jytCom_Click(object sender, EventArgs e)
        {
            //判断是否连接了
            if (isMonitor == false)
            {
                try
                {
                    //创建客户端对象 初始化
                    tcpclient = new TcpClient();
                    //连接服务端
                    tcpclient.Connect(jytServerIPText.Text.Trim(), (int)jytServerPort.Value);
                    /* NetworkStream strem = client.GetStream();
                    string str = this.textBox1.Text.Trim();
                    byte[] b = Encoding.UTF8.GetBytes(str);
                    strem.Write(b, 0, b.Length);
                    strem.Close();
                    client.Close();*/

                    //初始化 监听服务端回传消息 线程
                    th = new Thread(Recive);
                    //设置 后台线程
                    th.IsBackground = true;
                    //启动线程 传递对象
                    th.Start(tcpclient);

                    //启动监听
                    isMonitor = true;
                    jytCom.Text = "关闭连接";

                    //连接成功 设置控件不可用
                    jytServerIPText.Enabled = false;
                    jytServerPort.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //关闭监听
                tcpclient.Close();
                try
                {
                    if (thread != null) {
                        thread.Abort();
                        jytAutoSend.Text = "循环发送";
                    }
                        

                }
                catch
                {

                }
                isMonitor = false;
                jytCom.Text = "连接";
                //设置控件可用
                jytServerIPText.Enabled = true;
                jytServerPort.Enabled = true;
            }
        }

        // 线程方法 获取服务端回传 消息
        void Recive(object client)
        {
            NetworkStream reciveStream = ((TcpClient)client).GetStream();
            //Socket socketSend = o as Socket;
            while (true)
            {
                try
                {
                    //NetworkStream nss = ((TcpClient)client).GetStream();
                    byte[] data2 = new byte[1024 * 1024];//存储服务端发送过来的数据
                    int _length = reciveStream.Read(data2, 0, data2.Length);
                    if (_length > 0)
                    {
                        string msg = Encoding.Default.GetString(data2, 0, _length);
                    
                        
                        //调用 写入数据方法 把数据信息转成 选定的编码格式数据
                        JytAddData(("从ip：" + ((TcpClient)client).Client.RemoteEndPoint.ToString() + "收到了数据："), System.Text.Encoding.Default.GetBytes(msg));

                        // JytAddData(((IPEndPoint)((TcpClient)client).Client.LocalEndPoint).Port + "->" + ((TcpClient)client).Client.RemoteEndPoint.ToString() + ":", System.Text.Encoding.Default.GetBytes(msg));
                        // ShowMsg(socketSend.RemoteEndPoint + ":" + str);
                    }
                    else
                    {
                        try
                        {
                            
                            if (((TcpClient)client) != null && ((TcpClient)client).Connected)
                            {
                                // NetworkStream ns = ((TcpClient)client).GetStream();
                                //ns.Close();
                                reciveStream.Close();
                                ((TcpClient)client).Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "错误");
                        }

                    }

                }
                catch
                {
                    th.Abort();

                }
            }
        }
        //处理发送数据 时 将内容转换为 选择jytCodingtype的编码格式数据
        private byte[] JytTransformation(string textdata)
        {
            byte[] data = null;
            switch (jytCodingtype)
            {
                case 0:
                    string[] HexStr = textdata.Trim().Split(' ');
                    data = new byte[HexStr.Length];
                    for (int i = 0; i < HexStr.Length; i++)
                    {
                        data[i] = (byte)(Convert.ToInt32(HexStr[i], 16));
                    }
                    break;
                case 1:
                    data = new ASCIIEncoding().GetBytes(textdata);
                    break;
                case 2:
                    data = new UTF8Encoding().GetBytes(textdata);
                    break;
                case 3:
                    data = Encoding.GetEncoding("GB2312").GetBytes(textdata);
                    break;
            }
            return data;
        }
        //处理返回值 将返回的数据 转成jytCodingtype 选择的编码格式
        public void JytAddData(string ClientIPtxt, byte[] data)
        {

            switch (jytCodingtype)
            {
                case 0:
                    //16进制显示
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < data.Length; i++)
                    {
                        sb.AppendFormat("{0:x2}" + " ", data[i]);
                    }
                    JytAddContent(ClientIPtxt, sb.ToString().ToUpper());
                    break;
                case 1:
                    //ASCII码显示
                    JytAddContent(ClientIPtxt, new ASCIIEncoding().GetString(data));
                    break;
                case 2:
                    //GB2312显示
                    JytAddContent(ClientIPtxt, Encoding.GetEncoding("GB2312").GetString(data));
                    break;
                case 3:
                    //UTF8显示
                    JytAddContent(ClientIPtxt, new UTF8Encoding().GetString(data));

                    break;
            }

        }
        // 文本框输出返回内容
        //写入http中转数据
        private void JytAddContent(string ClientIPtxt, string content)
        {

            this.BeginInvoke(new MethodInvoker(delegate
            {
                if (jytAutoLine.Checked && jyttxtData.Text.Length > 0)
                {
                    jyttxtData.AppendText("\r\n");
                }
                // 文本框输出返回内容
                jyttxtData.AppendText(ClientIPtxt + content);
                //写入http中转数据
                jythttpReturnValue.TcpClientData = jyttxtData.Text;
            }));
        }
        //点击 jytCMD数据表格 每条的发送按钮 实现直接 发送数据
        private void jytCMD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string buttonText = this.jytCMD.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if (buttonText == "发送")
            {

                JytSendOut(this.jytCMD.Rows[e.RowIndex].Cells[1].Value.ToString());

            }
        }
    }
}
