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
    public partial class jytUdpClientFrom : Form
    {
        public jytUdpClientFrom()
        {
             Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        private Socket udpServer;
        bool isMonitor = false;
        private void jytCom_Click(object sender, EventArgs e)
        {
            Console.WriteLine(isMonitor);
            if (isMonitor == false)
            {
                try
                {
                    //1,创建socket
                    udpServer = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    //2,绑定ip跟端口号
                    if (jytServerIP.SelectedIndex == 0)
                    {

                        udpServer.Bind(new IPEndPoint(IPAddress.Any, (int)jytServerPort.Value));
                    }
                    else
                    {

                        udpServer.Bind(new IPEndPoint(IPAddress.Parse(jytServerIP.SelectedItem.ToString()), (int)jytServerPort.Value));
                    }


                    //3，接收数据
                    new Thread(ReceiveMessage) { IsBackground = true }.Start();
                    this.jytCom.Text = "关闭监听";
                    //设置控件不可用
                    jytServerIP.Enabled = false;
                    jytServerPort.Enabled = false;
                    isMonitor = true;

                    //只有客户端开启服务是会想服务端发送一条消息
                    //客户端发送数据到服务端
                    SendMessage("00",this.target.Text.Substring(0,this.target.Text.IndexOf(":")), int.Parse(this.target.Text.Substring(this.target.Text.IndexOf(":")+1)));

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                
                try
                {
                    udpServer.Dispose();
                    udpServer.Close();
                    
                }
                catch
                {
                }
                try
                {
                    if (thread != null)
                    {
                        thread.Abort();
                        jytAutoSend.Text = "循环发送";
                    }

                }
                catch
                {
                }

                isMonitor = false;
                jytCom.Text = "启动监听";
                jytServerIP.Enabled = true;
                jytServerPort.Enabled = true;
            }

            }
        /// 客户端连接初始化
       // public static List<string> dictInfo = new List<string>();
        void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    byte[] data = new byte[1024];
                    int length = udpServer.ReceiveFrom(data, ref remoteEndPoint);//这个方法会把数据的来源(ip:port)放到第二个参数上

                    string msg = Encoding.Default.GetString(data, 0, length);
                    /*if (!dictInfo.Contains((udpServer.LocalEndPoint as IPEndPoint).Port + "->" + (remoteEndPoint as IPEndPoint).Address.ToString() + ":" + (remoteEndPoint as IPEndPoint).Port))
                    {
                        dictInfo.Add((udpServer.LocalEndPoint as IPEndPoint).Port + "->" + (remoteEndPoint as IPEndPoint).Address.ToString() + ":" + (remoteEndPoint as IPEndPoint).Port);
                        jytConn.Invoke(new MethodInvoker(delegate {
                            jytConn.DataSource = null;
                            jytConn.DataSource = dictInfo;
                            jytConn.DisplayMember = "Name";
                        }));
                    }*/


                    //Console.WriteLine("从ip：" + (remoteEndPoint as IPEndPoint).Address.ToString() + "：" + (remoteEndPoint as IPEndPoint).Port + "收到了数据：" + message);
                    JytAddData(("从ip：" + (remoteEndPoint as IPEndPoint).Address.ToString() + "：" + (remoteEndPoint as IPEndPoint).Port + "收到了数据："), System.Text.Encoding.Default.GetBytes(msg));

                }
                catch {
                    /*  try
                     {
                         dictInfo.RemoveAt(jytConn.SelectedIndex);

                          jytConn.Invoke(new MethodInvoker(delegate {
                              jytConn.DataSource = null;
                              jytConn.DataSource = dictInfo;
                              jytConn.DisplayMember = "Name";
                          }));
                      }
                      catch { }*/

                    try
                    {
                        if (thread != null)
                        {
                            thread.Abort();
                            jytAutoSend.Text = "循环发送";
                            isMonitor = true;
                        }

                    }
                    catch
                    {

                    }
                }
              
            }

        }
        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="data">发送的信息</param>
        /// <param name="ip">要接受的ip</param>
        /// <param name="port">要接受的端口</param>
       // private static UdpClient udpcSend = null;

        private  void SendMessage(string data,string ip,int port)
        {
            try
            {
                EndPoint point = new IPEndPoint(IPAddress.Parse(ip), port);
                
                byte[] sendbytes = JytTransformation(data);
                udpServer.SendTo(sendbytes, point);
                
                /*
                byte[] sendbytes = JytTransformation(data);
                IPEndPoint remoteIpep = new IPEndPoint(IPAddress.Parse(ip), port); // 发送到的IP地址和端口号
                udpcSend.Send(sendbytes, sendbytes.Length, remoteIpep);
                //udpcSend.Close();
                */
            }
            catch { }
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




        //创建httpTcp内容
        JytHttpReturnValue jythttpReturnValue = new JytHttpReturnValue();
        
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
                jyttxtData.AppendText(ClientIPtxt + content);
                jythttpReturnValue.UdpClientData = jyttxtData.Text;
            }));
        }

        private void jytUdpServerFrom_Load(object sender, EventArgs e)
        {
            if (this.DesignMode == false)
            {
                jytServerIP.SelectedIndex = 0;
                IPHostEntry ipHostEntry = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in ipHostEntry.AddressList)
                {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {//筛选IPV4
                        jytServerIP.Items.Add(ip.ToString());
                    }
                }
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.jytCmdTxt.Text != "")
                SendMessage(this.jytCmdTxt.Text, this.target.Text.Substring(0, this.target.Text.IndexOf(":")), int.Parse(this.target.Text.Substring(this.target.Text.IndexOf(":") + 1)));

           
        }

        private void 断开连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* dictInfo.RemoveAt(jytConn.SelectedIndex);
          
            jytConn.Invoke(new MethodInvoker(delegate {
                jytConn.DataSource = null;
                jytConn.DataSource = dictInfo;
                jytConn.DisplayMember = "Name";
            }));*/
        }

        // jytMenu菜单控件的 添加按钮 
        // 右键 右侧datagridview jytCMD数据区 点击添加按钮
        private void MS_Add_Click(object sender, EventArgs e)
        {
            jytAddCmdTxts f2 = new jytAddCmdTxts("");
            if (f2.ShowDialog() == DialogResult.OK)
            {

                int index = this.jytCMD.Rows.Add();
                this.jytCMD.Rows[index].Cells[0].Value = false;
                this.jytCMD.Rows[index].Cells[1].Value = f2.TextBoxValue;
                this.jytCMD.Rows[index].Cells[2].Value = "发送";
                f2.Close();
            }
        }
        //jytCMD 数据表控件右键 点击修改功能
        private void MS_Edit_Click(object sender, EventArgs e)
        {
            try
            {
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
        //点击 jytCMD数据表格 每条的发送按钮 实现直接 发送数据
        private void jytCMD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string buttonText = this.jytCMD.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if (buttonText == "发送")
            {

                
                
                SendMessage(this.jytCMD.Rows[e.RowIndex].Cells[1].Value.ToString(), this.target.Text.Substring(0, this.target.Text.IndexOf(":")), int.Parse(this.target.Text.Substring(this.target.Text.IndexOf(":") + 1)));


            }
        }
        Thread thread;
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
                thread = new Thread(JytCircularTransmission);//创建线程

                thread.Start();//启动线程

                jytAutoSend.Text = "停止发送";
            }
            else
            {
                try { thread.Abort(); } catch { }
                
                jytAutoSend.Text = "循环发送";
                MessageBox.Show("监听未打开", "错误");
            }
        }
        //循环发送
        private void JytCircularTransmission()
        {
            try
            {
                if (isMonitor)
                {
                    while (true)
                    {

                        foreach (DataGridViewRow rowitme in this.jytCMD.Rows)
                        {

                            if (rowitme.Cells[0].Value.ToString() == "True")
                            {
                                Thread.Sleep(int.Parse(jytDelay.Value.ToString()));

                                 SendMessage(rowitme.Cells[1].Value.ToString(), this.target.Text.Substring(0, this.target.Text.IndexOf(":")), int.Parse(this.target.Text.Substring(this.target.Text.IndexOf(":") + 1)));

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

        private void target_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9')|| e.KeyChar=='.'|| e.KeyChar==':'|| e.KeyChar == '\b')
            {
                e.Handled = false;
                return;
            }
            else
            {
                e.Handled = true;

            }
        }
    }
}
