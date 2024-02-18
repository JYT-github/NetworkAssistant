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
    public partial class jytTcpServerFrom : Form
    {
        public jytTcpServerFrom()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        //创建httpTcp内容
        JytHttpReturnValue jythttpReturnValue = new JytHttpReturnValue();
        

        //把数据信息转成 选定的编码格式数据 再 调用添加数据 方法
        public void JytAddData(string ClientIPtxt,byte[] data)
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
                    JytAddContent(ClientIPtxt,sb.ToString().ToUpper());
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

        //写入http中转数据
        //键数据添加到窗体底部文本框
        private void JytAddContent(string ClientIPtxt,string content)
        {

            this.BeginInvoke(new MethodInvoker(delegate
            {
                if (jytAutoLine.Checked && jyttxtData.Text.Length > 0)
                {
                    jyttxtData.AppendText("\r\n");
                }
                jyttxtData.AppendText(ClientIPtxt+content);
                jythttpReturnValue.TcpServerData = jyttxtData.Text;
            }));
        }

        // TCP服务端监听
        TcpListener tcpsever = null;
        //是否启动 连接了
        bool isMonitor = false;
        //点击连接按钮
        private void jytCom_Click(object sender, EventArgs e)
        {
            if (isMonitor == false)
            {
                try
                {
                    if (jytServerIP.SelectedIndex == 0)
                    {
                        tcpsever = new TcpListener(IPAddress.Any, (int)jytServerPort.Value);
                    }
                    else
                    {
                        tcpsever = new TcpListener(IPAddress.Parse(jytServerIP.SelectedItem.ToString()), (int)jytServerPort.Value);
                    }
                    tcpsever.Start();
                    tcpsever.BeginAcceptTcpClient(new AsyncCallback(Acceptor), tcpsever);
                    //启动监听
                    isMonitor = true;
                    jytCom.Text = "关闭监听";

                    //设置控件不可用
                    jytServerIP.Enabled = false;
                    jytServerPort.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else {
                //关闭监听
                tcpsever.Stop();
                //循环关闭客户端列表监听
                foreach (Thread itemthread in jytTcpClientThreads) {
                    itemthread.Abort();
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
                //设置控件可用
                jytServerIP.Enabled = true;
                jytServerPort.Enabled = true;
            }
           
        }

        /// 客户端连接初始化
        public static List<string> dictInfo = new List<string>();
        //连接的客户端列表
        public static List<TcpClient> jytTcpClients = new List<TcpClient>();
        //连接的客户端监听列表
        public static List<Thread> jytTcpClientThreads = new List<Thread>();
        
        private void Acceptor(IAsyncResult o)
        {
            TcpListener server = o.AsyncState as TcpListener;
            try
            {
                //初始化连接的客户端
                //NetWorks server.EndAcceptTcpClient(o);
                TcpClient jytTcpClient = server.EndAcceptTcpClient(o);
                jytTcpClients.Add(jytTcpClient);
                
                dictInfo.Add(((IPEndPoint)jytTcpClient.Client.LocalEndPoint).Port+"->"+jytTcpClient.Client.RemoteEndPoint.ToString());
                server.BeginAcceptTcpClient(new AsyncCallback(Acceptor), server);//继续监听客户端连接
               
                
                jytConn.Invoke(new MethodInvoker(delegate {
                    jytConn.DataSource = null;
                    jytConn.DataSource = dictInfo;
                    jytConn.DisplayMember = "Name";
                }));

                Thread th = new Thread(Recive);
                jytTcpClientThreads.Add(th);
                th.IsBackground = true;
                th.Start(jytTcpClient);
            }
            catch (ObjectDisposedException ex)
            { //监听被关闭
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Recive(object client)
        {
            NetworkStream reciveStream = ((TcpClient)client).GetStream();
            //Socket socketSend = o as Socket;
            while (true)
            {
                try
                {
                    NetworkStream nss = ((TcpClient)client).GetStream();
                    byte[] data2 = new byte[1024 * 1024];//存储客户端发送过来的数据
                   int _length= reciveStream.Read(data2, 0, data2.Length);
                    if (_length > 0)
                    {
                        string msg = Encoding.Default.GetString(data2, 0, _length);
                        //int length = socketSend.Receive(data2);
                        //string message2 = Encoding.UTF8.GetString(data2, 0, length);
                        //Console.WriteLine("接收到客户端发送的消息" + message2);

                        
                        

                        JytAddData(("从ip：" + ((TcpClient)client).Client.RemoteEndPoint.ToString() + "收到了数据："), System.Text.Encoding.Default.GetBytes(msg));

                        //JytAddData(((IPEndPoint)((TcpClient)client).Client.LocalEndPoint).Port + "->" + ((TcpClient)client).Client.RemoteEndPoint.ToString()+":" , System.Text.Encoding.Default.GetBytes(msg));
                        // ShowMsg(socketSend.RemoteEndPoint + ":" + str);
                    }
                    else {
                        try
                        {
                            if (((TcpClient)client) != null && ((TcpClient)client).Connected)
                            {
                                NetworkStream ns = ((TcpClient)client).GetStream();
                                ns.Close();
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
                { }
            }
        }
        private void jytTcpServerFrom_Load(object sender, EventArgs e)
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

        private void jytOutTxtClear_Click(object sender, EventArgs e)
        {
            jyttxtData.Text = "";
        }

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
                thread.Abort();
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

                                byte[] _jytbyte = JytTransformation(rowitme.Cells[1].Value.ToString());// System.Text.Encoding.Default.GetBytes(rowitme.Cells[1].Value.ToString());
                                jytTcpClients[jytConn.SelectedIndex].GetStream().Write(_jytbyte, 0, _jytbyte.Length);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.jytCmdTxt.Text!="")
                JytSendOut(this.jytCmdTxt.Text);
        }
        //发送单条
        public void JytSendOut(string data)
        {

            try
            {
                byte[] _jytbyte = JytTransformation(data);// System.Text.Encoding.Default.GetBytes(data);
                jytTcpClients[jytConn.SelectedIndex].GetStream().Write(_jytbyte, 0, _jytbyte.Length);
            }
            catch
            {
                MessageBox.Show("发送失败", "错误");
            }
        }

        private void jytCMD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string buttonText = this.jytCMD.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if (buttonText == "发送")
            {

                JytSendOut(this.jytCMD.Rows[e.RowIndex].Cells[1].Value.ToString());

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

        private void 断开连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < jytConn.Items.Count; i++)
            {
                if (jytConn.SelectedIndex != -1)
                {
                    //右键断开时，释放客户端所有关系
                    try { dictInfo.RemoveAt(i); } catch { }
                    try { jytTcpClients.RemoveAt(i); } catch { }
                    try { jytTcpClientThreads[i].Abort(); } catch { }
                    try { jytTcpClientThreads.RemoveAt(i); } catch { }

                    
                    
                    
                }
            }
            //重新绑定列表
            jytConn.Invoke(new MethodInvoker(delegate {
                jytConn.DataSource = null;
                jytConn.DataSource = dictInfo;
                jytConn.DisplayMember = "Name";
            }));
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
        /**
         *处理发送字符 十六进制    ASCII     UTF8    GB2312
         * */
        /*
         switch (_EncodeType)
        {
            case EnumType.DataEncode.Hex:
                string[] HexStr = this.Text.Trim().Split(' ');
                data = new byte[HexStr.Length];
                for (int i = 0; i < HexStr.Length; i++)
                {
                    data[i] = (byte)(Convert.ToInt32(HexStr[i], 16));
                }
                break;
            case EnumType.DataEncode.ASCII:
                data = new ASCIIEncoding().GetBytes(this.Text);
                break;
            case EnumType.DataEncode.UTF8:
                data = new UTF8Encoding().GetBytes(this.Text);
                break;
            case EnumType.DataEncode.GB2312:
                data = Encoding.GetEncoding("GB2312").GetBytes(this.Text);
                break;
        }
        switch (value)
        {
            case EnumType.DataEncode.Hex:
                if (this.Text.Length > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < data.Length; i++)
                    {
                        sb.AppendFormat("{0:x2} ", data[i]);
                    }
                    this.Text = sb.ToString().Trim().ToUpper();
                }
                break;
            case EnumType.DataEncode.ASCII:
                this.Text = new ASCIIEncoding().GetString(data);
                break;
            case EnumType.DataEncode.UTF8:
                this.Text = new UTF8Encoding().GetString(data);
                break;
            case EnumType.DataEncode.GB2312:
                this.Text = Encoding.GetEncoding("GB2312").GetString(data);
                break;
        }
         */
    }
}
