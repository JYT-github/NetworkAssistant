using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 自制网络助手
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //创建一个 线程 
        //功能：http服务功能
        Thread _httpServer;


        //创建一个各个通信方式，存放内容的中转
        JytHttpReturnValue jythttpReturnValue = new JytHttpReturnValue();

        //点击 启动http服务 菜单按钮事件
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //判断 是否已经启动了http服务
            if (toolStripMenuItem1.Text == "启动Http服务")
            {
                //修改菜单按钮 内容
                toolStripMenuItem1.Text = "停止Http服务";

                //编写 线程执行逻辑 （这里没有启动哈）
                _httpServer = new Thread(delegate ()
                {
                    //捕获异常
                    try
                    {
                        /*
                         using 关键字有两个主要用途：
                          (一).作为指令，用于为命名空间创建别名或导入其他命名空间中定义的类型。
                          (二).作为语句，用于定义一个范围，在此范围的末尾将释放对象。

                        创建http服务
                         */
                        using (HttpListener listerner = new HttpListener())
                        {
                            //指定身份验证 Anonymous匿名访问
                            listerner.AuthenticationSchemes = AuthenticationSchemes.Anonymous;

                            //设置 http 服务 地址
                            //http://localhost:8080/web/
                            listerner.Prefixes.Add(toolStripTextBox1.Text);
                            //启动服务
                            listerner.Start();

                            //很显然 我是用控制台程序改的这个功能
                            //Console.WriteLine("WebServer Start Successed.......");
                            HttpListenerContext ctx;
                            while (true)
                            {
                                //等待请求连接
                                //没有请求则GetContext处于阻塞状态
                                ctx = listerner.GetContext();
                                //设置返回给客服端http状态代码
                                ctx.Response.StatusCode = 200;
                                string name = ctx.Request.QueryString["name"];

                                if (name != null)
                                {
                                    Console.WriteLine(name);
                                }


                                //使用Writer输出http响应代码
                                using (StreamWriter writer = new StreamWriter(ctx.Response.OutputStream, Encoding.UTF8))
                                {
                                    // Console.WriteLine("hello");
                                    writer.WriteLine("SerialPortData-------------------------------");
                                    writer.WriteLine(jythttpReturnValue.SerialPortData);
                                    writer.WriteLine("TcpClientData-------------------------------");
                                    writer.WriteLine(jythttpReturnValue.TcpClientData);
                                    writer.WriteLine("TcpServerData-------------------------------");
                                    writer.WriteLine(jythttpReturnValue.TcpServerData);
                                    writer.WriteLine("UdpClientData-------------------------------");
                                    writer.WriteLine(jythttpReturnValue.UdpClientData);
                                    writer.WriteLine("UdpServerData-------------------------------");
                                    writer.WriteLine(jythttpReturnValue.UdpServerData);

                                    
                                    /* 
                                     这是留着给你们 参考 怎么返回html页面内容 
                                     writer.WriteLine("<html><head><title>The WebServer Test</title></head><body>");
                                     writer.WriteLine("<div style=\"height:20px;color:blue;text-align:center;\"><p> hello {0}</p></div>", name);
                                     writer.WriteLine("<ul>");

                                     foreach (string header in ctx.Request.Headers.Keys)
                                     {
                                         writer.WriteLine("<li><b>{0}:</b>{1}</li>", header, ctx.Request.Headers[header]);

                                     }
                                     writer.WriteLine("</ul>");
                                     writer.WriteLine("</body></html>");*/

                                    writer.Close();
                                    ctx.Response.Close();
                                }

                            }
                            listerner.Stop();
                        }
                    }
                    catch {
                        MessageBox.Show("启动Http失败：查看地址是否真确，或端口被占用");
                        //如果 启动失败 修改菜单按钮内容
                        toolStripMenuItem1.Text = "启动Http服务";
                        //终止线程
                        _httpServer.Abort();
                    }
                    
                });
                //启动线程（这里启动的）
                _httpServer.Start();
            }
            else {
                toolStripMenuItem1.Text = "启动Http服务";
                //终止线程
                _httpServer.Abort();

               
            }
        }

        /*
         功能：将 当前程序的某一窗口程序 显示到指定容器控件上（大概就是这个意思）
             */
        private void OpenFrom(Form objFrm,object objParent)
        {

            //将当前子窗体设置成非顶级控件
            objFrm.TopLevel = false;
            //设置窗体最大化
            objFrm.WindowState = FormWindowState.Maximized;
            //去掉窗体边框
            objFrm.FormBorderStyle = FormBorderStyle.None;
            //指定当前子窗体显示的容器
            objFrm.Parent = (Control)objParent;
            //显示窗体
            objFrm.Show();
        }

        //初始化窗口
        //使当前所有 方法 都可以访问
        jytSerialPortForm _jytserialportForm = null;
        jytTcpServerFrom _jyttcpserverFrom = null;
        jytTcpClientFrom _jyttcpclientFrom = null;
        jytUdpServerFrom _jytudpserverFrom = null;
        jytUdpClientFrom _jytudpclientFrom = null;

        //窗体载入
        private void Form1_Load(object sender, EventArgs e)
        {
            //加载窗体 tabControl 下标默认为0 是串口窗体
            //默认 打开 串口窗体
            _jytserialportForm = new jytSerialPortForm();
            //设置将子窗口 与 父控件 撑满 （子窗口各边缘 停靠在父控件各边缘）
            _jytserialportForm.Dock = DockStyle.Fill;
            //调用方法将 指定窗口 显示在指定控件内
            OpenFrom(_jytserialportForm, this.jytSerialPort);
        }


        /*
             主窗口 tabControl 控件 
             功能：点击tab切换窗口事件 
         */
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //通过 tabControl 控件 下标 区分打开的是那个窗体
            switch (this.tabControl1.SelectedIndex)
            {
                case 0:
                    //判断是否是第一次打开当前 tabPage 页 
                    //如果是 第一次 那么就创建窗体
                    //如果不是 那么 这个窗体已经存在了，不可重复在当前父控件多次创建子窗体
                    if (_jytserialportForm == null) {
                        //创建窗口
                        _jytserialportForm = new jytSerialPortForm();
                        //设置将子窗口 与 父控件 撑满 （子窗口各边缘 停靠在父控件各边缘）
                        _jytserialportForm.Dock = DockStyle.Fill;
                        //调用方法将 指定窗口 显示在指定控件内
                        OpenFrom(_jytserialportForm, this.jytSerialPort);
                    }
                    break;
                case 1:
                    if (_jyttcpserverFrom == null)
                    {
                        _jyttcpserverFrom = new jytTcpServerFrom();
                        _jyttcpserverFrom.Dock = DockStyle.Fill;
                        OpenFrom(_jyttcpserverFrom, this.jytTcpServer);
                    }
                    break;
                case 2:
                    if (_jyttcpclientFrom == null)
                    {
                        _jyttcpclientFrom = new jytTcpClientFrom();
                        _jyttcpclientFrom.Dock = DockStyle.Fill;
                        OpenFrom(_jyttcpclientFrom, this.jytTcpClient);
                    }
                    break;
                case 3:
                    if (_jytudpserverFrom == null)
                    {
                        _jytudpserverFrom = new jytUdpServerFrom();
                        _jytudpserverFrom.Dock = DockStyle.Fill;
                        OpenFrom(_jytudpserverFrom, this.jytUdpServer);
                    }
                    break;
                case 4:
                    if (_jytudpclientFrom == null)
                    {
                        _jytudpclientFrom = new jytUdpClientFrom();
                        _jytudpclientFrom.Dock = DockStyle.Fill;
                        OpenFrom(_jytudpclientFrom, this.jytUdpClient);
                    }
                    break;
             

            }
        }


       

        private void 串口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //创建一个串口窗体程序
            jytSerialPortForm SerialPort = new jytSerialPortForm();

            //将串口窗体程序显示
            SerialPort.Show();
        }

        private void tcpServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //创建一个TCP服务端窗体程序
            jytTcpServerFrom TcpServer = new jytTcpServerFrom();

            //将TCP服务端窗体程序显示
            TcpServer.Show();
        }

        private void tcpClientToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //创建一个TCP客户端窗体程序
            jytTcpClientFrom TcpClient = new jytTcpClientFrom();

            //将TCP客户端窗体程序显示
            TcpClient.Show();
        }

        private void udpServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //创建一个UDP服务端窗体程序
            jytUdpServerFrom UdpServer = new jytUdpServerFrom();

            //将UDP服务端窗体程序显示
            UdpServer.Show();
        }
        private void udpClicentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //创建一个UDP客户端窗体程序
            jytUdpClientFrom UdpClient = new jytUdpClientFrom();

            //将UDP客户端窗体程序显示
            UdpClient.Show();
        }
       
    }
}
