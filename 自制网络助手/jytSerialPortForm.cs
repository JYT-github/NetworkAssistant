using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 自制网络助手
{
    public partial class jytSerialPortForm : Form
    {
        public jytSerialPortForm()
        {
            InitializeComponent();
        }

        /*
         * 窗口控件 
         jytComList:选择串口下拉列表
         jytBaudRate：波特率下拉列表
         jytCheckBit：校验位下拉列表
         jytDataBits：数据位下拉列表
         jytStopBit：停止位下拉列表
         jytCom：打开串口按钮
         其他控件自行 脑补
             */
        //创建 循环发送线程 懒得起名字
        Thread thread;

        //创建 串口接口对象
        private SerialPort jytComDevice;
        //窗体载入
        private void jytSerialPortForm_Load(object sender, EventArgs e)
        {
            //获取所有串口名称 添加到 jytComList下拉列表控件
            jytComList.Items.AddRange(SerialPort.GetPortNames());

            //如果下拉列表 的个数大于0 默认选择第一个
            if (jytComList.Items.Count > 0)
            {
                //默认选择第一个
                jytComList.SelectedIndex = 0;
                //修改 链接 打开串口按钮 可操作
                jytCom.Enabled = true;
            }
            //设置 各下拉按钮 默认选择
            //下拉列表项 需要在窗口编辑器 当前控件属性中的items 自行添加 
            jytBaudRate.SelectedIndex = 5;
            jytCheckBit.SelectedIndex = 0;
            jytDataBits.SelectedIndex = 0;
            jytStopBit.SelectedIndex = 0;
        }

        //创建一个各个通信方式，存放内容的中转
        JytHttpReturnValue jythttpReturnValue = new JytHttpReturnValue();
        //点击打开串口
        private void jytCom_Click(object sender, EventArgs e)
        {
            //判断 串口对象是否创建 是打开状态 
            //如果不是 就 启动串口链接
            //好像这里和主窗体 启动http服务按钮的判断逻辑有些区别 （自行脑补吧）
            if (jytComDevice==null || jytComDevice.IsOpen == false)
            {
                //创建串口  SerialPort 这个东东是 c# 自带的哈   顶部引入 using System.IO.Ports;
                jytComDevice = new SerialPort();
                //设置串口 连接时的参数
                jytComDevice.PortName = jytComList.SelectedItem.ToString();
                jytComDevice.BaudRate = Convert.ToInt32(jytBaudRate.SelectedItem.ToString());
                jytComDevice.Parity = (Parity)Convert.ToInt32(jytCheckBit.SelectedIndex.ToString());
                jytComDevice.DataBits = Convert.ToInt32(jytDataBits.SelectedItem.ToString());
                jytComDevice.StopBits = (StopBits)Convert.ToInt32(jytStopBit.SelectedItem.ToString());
                try
                {
                    //这个不用多说了
                    jytComDevice.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误");
                    return;
                }
                //修改内容
                jytCom.Text = "关闭串口";
              
            }
            else
            {
                try
                {
                    //不多说了
                    jytComDevice.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误");
                }
                jytCom.Text = "打开串口";
                try
                {
                    if (thread != null)
                    {
                        thread.Abort();
                        jytAutoSend.Text = "循环发送";
                    }
                       
                }
                catch {

                }

                jytAutoSend.Text = "循环发送";

            }


            //点击打开串口按钮  如果连接了串口 就设置这些下拉列表不可改状态  true那么就取反 
            jytComList.Enabled = !jytComDevice.IsOpen;
            jytBaudRate.Enabled = !jytComDevice.IsOpen;
            jytCheckBit.Enabled = !jytComDevice.IsOpen;
            jytDataBits.Enabled = !jytComDevice.IsOpen;
            jytStopBit.Enabled = !jytComDevice.IsOpen;

            //绑定接受数据 的方法Com_DataReceived 获取串口接收到的数据信息 
            jytComDevice.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived);
        }
        
        //读取串口 获取到的数据信息  只要接受到消息就会执行（大概就是这个意思）
        private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            byte[] ReDatas = new byte[jytComDevice.BytesToRead];
            jytComDevice.Read(ReDatas, 0, ReDatas.Length);//读取数据

            //调用 写入数据方法 把数据信息转成 选定的编码格式数据
            JytAddData(ReDatas);
        }

        //把数据信息转成 选定的编码格式数据 再 调用添加数据 方法
        public void JytAddData(byte[] data)
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
                    JytAddContent(sb.ToString().ToUpper());
                    break;
                case 1:
                    //ASCII码显示
                    JytAddContent(new ASCIIEncoding().GetString(data));
                    break;
                case 2:
                    //GB2312显示
                    JytAddContent(Encoding.GetEncoding("GB2312").GetString(data));
                    break;
                case 3:
                    //UTF8显示
                    JytAddContent(new UTF8Encoding().GetString(data));

                    break;
            }

        }
        //写入http中转数据
        //键数据添加到窗体底部文本框
        private void JytAddContent(string content)
        {
            //子线程 给 主线程 文本框赋值
            this.BeginInvoke(new MethodInvoker(delegate
            {
                //判断是否自动换行  嗯嗯 jyttxtData.Text.Length > 0这个好像无意义 
                if (jytAutoLine.Checked && jyttxtData.Text.Length > 0)
                {
                    jyttxtData.AppendText("\r\n");
                }
                //添加到船体底部文本框
                jyttxtData.AppendText(content);
                //写入http中转数据
                jythttpReturnValue.SerialPortData = jyttxtData.Text;
            }));
        }

        // 串口发送数据 
        // 这里 调用来调用去的 写的有点乱
        public bool SendData(byte[] data)
        {
            //判断 串口是否打开
            if (jytComDevice.IsOpen)
            {
                try
                {
                    //发送数据 写入数据到串口
                    jytComDevice.Write(data, 0, data.Length);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误");
                }
            }
            else
            {
                //关闭线程
                thread.Abort();
                jytAutoSend.Text = "循环发送";
                MessageBox.Show("串口未打开", "错误");
            }
            return false;
        }

        //通过这个判断 选择的编码格式 下面这四个方法 （有更简单的方法实现这个，--->--->--->--->--->--->--->--->--->--->--->--->--->--->--->--->自行脑补吧）
        int jytCodingtype = 0;
        private void jytHex_CheckedChanged(object sender, EventArgs e)
        {
            if (jytHex.Checked) {
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
        private void jytGB2312_CheckedChanged(object sender, EventArgs e)
        {
            if (jytGB2312.Checked)
            {
                jytCodingtype = 2;
            }
        }
        private void jytUTF8_CheckedChanged(object sender, EventArgs e)
        {
            if (jytUTF8.Checked)
            {
                jytCodingtype =3;
            }
        }


        //循环发送按钮 点击事件
        private void jytAutoSend_Click(object sender, EventArgs e)
        {
            if (jytAutoSend.Text == "停止发送")
            {
                jytAutoSend.Text = "循环发送";
                thread.Abort();
                //timer1.Enabled = false;
                return;
            }
            //判断是否打开
            if (jytComDevice.IsOpen)
            {
                //创建一个循环发送消息的线程
                thread = new Thread(JytCircularTransmission);//创建线程

                thread.Start();//启动线程

                jytAutoSend.Text = "停止发送";
            }
            else
            {
                thread.Abort();
                jytAutoSend.Text = "循环发送";
                MessageBox.Show("串口未打开", "错误");
            }
        }


        //线程执行的方法 循环发送
        private void JytCircularTransmission() {
            try
            {
                //判断串口是否是打开状态
                if (jytComDevice.IsOpen)
                {
                    // 死循环 发送右侧 jytCMD 控件勾选了的 数据
                    while (true) {
                        //实时 获取 要发送的数据是否勾选了 可以在发送的时候 取消勾选 不发送
                        foreach (DataGridViewRow rowitme in this.jytCMD.Rows)
                        {
                            // 判断 复选框是否勾选了 （有其他方法）
                            if (rowitme.Cells[0].Value.ToString() == "True")
                            {
                                //发送一条 等待 设置的间隔事件 单位毫秒
                                Thread.Sleep(int.Parse(jytDelay.Value.ToString()));
                                //调用发送内容 方法 发送内容
                                SendData(System.Text.Encoding.Default.GetBytes(rowitme.Cells[1].Value.ToString()));
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
        //废弃的timer循环发送  因为会导致 界面卡死
        private void timer1_Tick(object sender, EventArgs e)
        {
           /* try
            {
                if (jytComDevice.IsOpen)
                {
                    foreach (DataGridViewRow rowitme in this.jytCMD.Rows)
                    {

                        if (rowitme.Cells[0].Value.ToString() == "True")
                        {
                            Thread.Sleep(int.Parse(jytDelay.Value.ToString()));
                            SendData(System.Text.Encoding.Default.GetBytes(rowitme.Cells[1].Value.ToString()));
                        }
                    }

                }
                else {
                    timer1.Enabled = false;
                    jytAutoSend.Text = "循环发送";
                }
            }
            catch
            {
                timer1.Enabled = false;
                jytAutoSend.Text = "循环发送";
                MessageBox.Show("发送失败", "错误");
            }*/
           
        }

        // jytMenu菜单控件的 添加按钮 
        // 右键 右侧datagridview jytCMD数据区 点击添加按钮
        private void MS_Add_Click(object sender, EventArgs e)
        {
            //这个是添加数据记录 的窗口 创建一个  向下传的这个值是否为了实现修改功能
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

        //点击发送按钮 发送数据
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.jytCmdTxt.Text != "")
                JytSendOut(this.jytCmdTxt.Text);
        }
        //发送单条
        //不知道为啥 单独写了一个这个 忘了 其实 单独写这个方法
        //直接在 调用处 调用SendData就可以 懒得改了
        public void JytSendOut(string data) {

            try
            {
                SendData(System.Text.Encoding.Default.GetBytes(data));
            }
            catch
            {
                MessageBox.Show("发送失败", "错误");
            }
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
            catch {

            }
           
        }

        //文本框右键 点击清空功能
        private void jytOutTxtClear_Click(object sender, EventArgs e)
        {
            jyttxtData.Text = "";
        }

        //当前窗口关闭时 执行
        private void jytSerialPortForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (jytComDevice.IsOpen)
                {
                    thread.Abort();
                    jytComDevice.Close();
                }
            }
            catch { }
           
        }

    
    }
}
