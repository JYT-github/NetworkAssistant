namespace 自制网络助手
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.创建调试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.串口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcpServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcpClientToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.udpServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.udpClicentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.jytSerialPort = new System.Windows.Forms.TabPage();
            this.jytTcpServer = new System.Windows.Forms.TabPage();
            this.jytTcpClient = new System.Windows.Forms.TabPage();
            this.jytUdpServer = new System.Windows.Forms.TabPage();
            this.jytUdpClient = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.创建调试ToolStripMenuItem,
            this.toolStripTextBox1,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1013, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 创建调试ToolStripMenuItem
            // 
            this.创建调试ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.串口ToolStripMenuItem,
            this.tcpServerToolStripMenuItem,
            this.tcpClientToolStripMenuItem1,
            this.udpServerToolStripMenuItem,
            this.udpClicentToolStripMenuItem});
            this.创建调试ToolStripMenuItem.Name = "创建调试ToolStripMenuItem";
            this.创建调试ToolStripMenuItem.Size = new System.Drawing.Size(68, 23);
            this.创建调试ToolStripMenuItem.Text = "创建调试";
            // 
            // 串口ToolStripMenuItem
            // 
            this.串口ToolStripMenuItem.Name = "串口ToolStripMenuItem";
            this.串口ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.串口ToolStripMenuItem.Text = "串口";
            this.串口ToolStripMenuItem.Click += new System.EventHandler(this.串口ToolStripMenuItem_Click);
            // 
            // tcpServerToolStripMenuItem
            // 
            this.tcpServerToolStripMenuItem.Name = "tcpServerToolStripMenuItem";
            this.tcpServerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tcpServerToolStripMenuItem.Text = "TcpServer";
            this.tcpServerToolStripMenuItem.Click += new System.EventHandler(this.tcpServerToolStripMenuItem_Click);
            // 
            // tcpClientToolStripMenuItem1
            // 
            this.tcpClientToolStripMenuItem1.Name = "tcpClientToolStripMenuItem1";
            this.tcpClientToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.tcpClientToolStripMenuItem1.Text = "TcpClient";
            this.tcpClientToolStripMenuItem1.Click += new System.EventHandler(this.tcpClientToolStripMenuItem1_Click);
            // 
            // udpServerToolStripMenuItem
            // 
            this.udpServerToolStripMenuItem.Name = "udpServerToolStripMenuItem";
            this.udpServerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.udpServerToolStripMenuItem.Text = "UdpServer";
            this.udpServerToolStripMenuItem.Click += new System.EventHandler(this.udpServerToolStripMenuItem_Click);
            // 
            // udpClicentToolStripMenuItem
            // 
            this.udpClicentToolStripMenuItem.Name = "udpClicentToolStripMenuItem";
            this.udpClicentToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.udpClicentToolStripMenuItem.Text = "UdpClient";
            this.udpClicentToolStripMenuItem.Click += new System.EventHandler(this.udpClicentToolStripMenuItem_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(180, 23);
            this.toolStripTextBox1.Text = "http://localhost:8080/web/";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(93, 23);
            this.toolStripMenuItem1.Text = "启动Http服务";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.jytSerialPort);
            this.tabControl1.Controls.Add(this.jytTcpServer);
            this.tabControl1.Controls.Add(this.jytTcpClient);
            this.tabControl1.Controls.Add(this.jytUdpServer);
            this.tabControl1.Controls.Add(this.jytUdpClient);
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1013, 639);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // jytSerialPort
            // 
            this.jytSerialPort.Location = new System.Drawing.Point(4, 22);
            this.jytSerialPort.Name = "jytSerialPort";
            this.jytSerialPort.Padding = new System.Windows.Forms.Padding(3);
            this.jytSerialPort.Size = new System.Drawing.Size(1005, 613);
            this.jytSerialPort.TabIndex = 0;
            this.jytSerialPort.Text = "串口";
            // 
            // jytTcpServer
            // 
            this.jytTcpServer.Location = new System.Drawing.Point(4, 22);
            this.jytTcpServer.Name = "jytTcpServer";
            this.jytTcpServer.Padding = new System.Windows.Forms.Padding(3);
            this.jytTcpServer.Size = new System.Drawing.Size(1005, 613);
            this.jytTcpServer.TabIndex = 1;
            this.jytTcpServer.Text = "TCP Server";
            this.jytTcpServer.UseVisualStyleBackColor = true;
            // 
            // jytTcpClient
            // 
            this.jytTcpClient.Location = new System.Drawing.Point(4, 22);
            this.jytTcpClient.Name = "jytTcpClient";
            this.jytTcpClient.Size = new System.Drawing.Size(1005, 613);
            this.jytTcpClient.TabIndex = 2;
            this.jytTcpClient.Text = "TCP Client";
            this.jytTcpClient.UseVisualStyleBackColor = true;
            // 
            // jytUdpServer
            // 
            this.jytUdpServer.Location = new System.Drawing.Point(4, 22);
            this.jytUdpServer.Name = "jytUdpServer";
            this.jytUdpServer.Size = new System.Drawing.Size(1005, 613);
            this.jytUdpServer.TabIndex = 3;
            this.jytUdpServer.Text = "UDP Server";
            this.jytUdpServer.UseVisualStyleBackColor = true;
            // 
            // jytUdpClient
            // 
            this.jytUdpClient.Location = new System.Drawing.Point(4, 22);
            this.jytUdpClient.Name = "jytUdpClient";
            this.jytUdpClient.Size = new System.Drawing.Size(1005, 613);
            this.jytUdpClient.TabIndex = 4;
            this.jytUdpClient.Text = "UDP Client";
            this.jytUdpClient.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 666);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
       
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 创建调试ToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage jytSerialPort;
        private System.Windows.Forms.TabPage jytTcpServer;
        private System.Windows.Forms.TabPage jytTcpClient;
        private System.Windows.Forms.TabPage jytUdpServer;
        private System.Windows.Forms.TabPage jytUdpClient;
        private System.Windows.Forms.ToolStripMenuItem 串口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tcpServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tcpClientToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem udpServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem udpClicentToolStripMenuItem;
    }
}

