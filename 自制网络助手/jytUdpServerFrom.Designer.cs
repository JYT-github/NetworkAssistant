namespace 自制网络助手
{
    partial class jytUdpServerFrom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.jytServerPort = new System.Windows.Forms.NumericUpDown();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.断开连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MS_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.MS_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.jytCmdTxt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.jytMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MS_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.jytGB2312 = new System.Windows.Forms.RadioButton();
            this.jytUTF8 = new System.Windows.Forms.RadioButton();
            this.jytASCII = new System.Windows.Forms.RadioButton();
            this.jytHex = new System.Windows.Forms.RadioButton();
            this.jytAutoLine = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.jytDelay = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.jyttxtData = new System.Windows.Forms.TextBox();
            this.jytMenuClear = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.jytOutTxtClear = new System.Windows.Forms.ToolStripMenuItem();
            this.jytCMD = new System.Windows.Forms.DataGridView();
            this.IsAutoSend = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CMDText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSend = new System.Windows.Forms.DataGridViewButtonColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.jytCom = new System.Windows.Forms.Button();
            this.jytServerIP = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.jytAutoSend = new System.Windows.Forms.Button();
            this.jytConn = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.jytServerPort)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.jytMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jytDelay)).BeginInit();
            this.jytMenuClear.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jytCMD)).BeginInit();
            this.SuspendLayout();
            // 
            // jytServerPort
            // 
            this.jytServerPort.Location = new System.Drawing.Point(51, 54);
            this.jytServerPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.jytServerPort.Name = "jytServerPort";
            this.jytServerPort.Size = new System.Drawing.Size(104, 21);
            this.jytServerPort.TabIndex = 72;
            this.jytServerPort.Value = new decimal(new int[] {
            2756,
            0,
            0,
            0});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.断开连接ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            // 
            // 断开连接ToolStripMenuItem
            // 
            this.断开连接ToolStripMenuItem.Name = "断开连接ToolStripMenuItem";
            this.断开连接ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.断开连接ToolStripMenuItem.Text = "断开连接";
            this.断开连接ToolStripMenuItem.Click += new System.EventHandler(this.断开连接ToolStripMenuItem_Click);
            // 
            // MS_Edit
            // 
            this.MS_Edit.Name = "MS_Edit";
            this.MS_Edit.Size = new System.Drawing.Size(100, 22);
            this.MS_Edit.Text = "编辑";
            this.MS_Edit.Click += new System.EventHandler(this.MS_Edit_Click);
            // 
            // MS_Add
            // 
            this.MS_Add.Name = "MS_Add";
            this.MS_Add.Size = new System.Drawing.Size(100, 22);
            this.MS_Add.Text = "添加";
            this.MS_Add.Click += new System.EventHandler(this.MS_Add_Click);
            // 
            // jytCmdTxt
            // 
            this.jytCmdTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jytCmdTxt.Location = new System.Drawing.Point(169, 219);
            this.jytCmdTxt.Multiline = true;
            this.jytCmdTxt.Name = "jytCmdTxt";
            this.jytCmdTxt.Size = new System.Drawing.Size(374, 71);
            this.jytCmdTxt.TabIndex = 54;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(167, 297);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 29);
            this.button1.TabIndex = 55;
            this.button1.Text = "发送";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // jytMenu
            // 
            this.jytMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MS_Add,
            this.MS_Edit,
            this.MS_Delete});
            this.jytMenu.Name = "contextMenuStrip1";
            this.jytMenu.Size = new System.Drawing.Size(101, 70);
            // 
            // MS_Delete
            // 
            this.MS_Delete.Name = "MS_Delete";
            this.MS_Delete.Size = new System.Drawing.Size(100, 22);
            this.MS_Delete.Text = "删除";
            this.MS_Delete.Click += new System.EventHandler(this.MS_Delete_Click);
            // 
            // jytGB2312
            // 
            this.jytGB2312.AutoSize = true;
            this.jytGB2312.Location = new System.Drawing.Point(79, 274);
            this.jytGB2312.Name = "jytGB2312";
            this.jytGB2312.Size = new System.Drawing.Size(59, 16);
            this.jytGB2312.TabIndex = 70;
            this.jytGB2312.Text = "GB2312";
            this.jytGB2312.UseVisualStyleBackColor = true;
            this.jytGB2312.CheckedChanged += new System.EventHandler(this.jytGB2312_CheckedChanged);
            // 
            // jytUTF8
            // 
            this.jytUTF8.AutoSize = true;
            this.jytUTF8.Location = new System.Drawing.Point(7, 274);
            this.jytUTF8.Name = "jytUTF8";
            this.jytUTF8.Size = new System.Drawing.Size(47, 16);
            this.jytUTF8.TabIndex = 69;
            this.jytUTF8.Text = "UTF8";
            this.jytUTF8.UseVisualStyleBackColor = true;
            this.jytUTF8.CheckedChanged += new System.EventHandler(this.jytUTF8_CheckedChanged);
            // 
            // jytASCII
            // 
            this.jytASCII.AutoSize = true;
            this.jytASCII.Location = new System.Drawing.Point(79, 243);
            this.jytASCII.Name = "jytASCII";
            this.jytASCII.Size = new System.Drawing.Size(53, 16);
            this.jytASCII.TabIndex = 68;
            this.jytASCII.Text = "ASCII";
            this.jytASCII.UseVisualStyleBackColor = true;
            this.jytASCII.CheckedChanged += new System.EventHandler(this.jytASCII_CheckedChanged);
            // 
            // jytHex
            // 
            this.jytHex.AutoSize = true;
            this.jytHex.Checked = true;
            this.jytHex.Location = new System.Drawing.Point(7, 243);
            this.jytHex.Name = "jytHex";
            this.jytHex.Size = new System.Drawing.Size(41, 16);
            this.jytHex.TabIndex = 67;
            this.jytHex.TabStop = true;
            this.jytHex.Text = "Hex";
            this.jytHex.UseVisualStyleBackColor = true;
            this.jytHex.CheckedChanged += new System.EventHandler(this.jytHex_CheckedChanged);
            // 
            // jytAutoLine
            // 
            this.jytAutoLine.AutoSize = true;
            this.jytAutoLine.Location = new System.Drawing.Point(8, 306);
            this.jytAutoLine.Name = "jytAutoLine";
            this.jytAutoLine.Size = new System.Drawing.Size(72, 16);
            this.jytAutoLine.TabIndex = 66;
            this.jytAutoLine.Text = "自动换行";
            this.jytAutoLine.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(399, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 64;
            this.label7.Text = "毫秒";
            // 
            // jytDelay
            // 
            this.jytDelay.Location = new System.Drawing.Point(325, 186);
            this.jytDelay.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.jytDelay.Name = "jytDelay";
            this.jytDelay.Size = new System.Drawing.Size(70, 21);
            this.jytDelay.TabIndex = 63;
            this.jytDelay.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(266, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 62;
            this.label8.Text = "发送间隔：";
            // 
            // jyttxtData
            // 
            this.jyttxtData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jyttxtData.ContextMenuStrip = this.jytMenuClear;
            this.jyttxtData.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.jyttxtData.Location = new System.Drawing.Point(8, 332);
            this.jyttxtData.MaxLength = 1;
            this.jyttxtData.Multiline = true;
            this.jyttxtData.Name = "jyttxtData";
            this.jyttxtData.ReadOnly = true;
            this.jyttxtData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.jyttxtData.Size = new System.Drawing.Size(535, 259);
            this.jyttxtData.TabIndex = 65;
            // 
            // jytMenuClear
            // 
            this.jytMenuClear.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jytOutTxtClear});
            this.jytMenuClear.Name = "contextMenuStrip1";
            this.jytMenuClear.ShowImageMargin = false;
            this.jytMenuClear.Size = new System.Drawing.Size(76, 26);
            // 
            // jytOutTxtClear
            // 
            this.jytOutTxtClear.Name = "jytOutTxtClear";
            this.jytOutTxtClear.Size = new System.Drawing.Size(75, 22);
            this.jytOutTxtClear.Text = "清空";
            // 
            // jytCMD
            // 
            this.jytCMD.AllowUserToAddRows = false;
            this.jytCMD.AllowUserToDeleteRows = false;
            this.jytCMD.AllowUserToResizeRows = false;
            this.jytCMD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jytCMD.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.jytCMD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.jytCMD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jytCMD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsAutoSend,
            this.CMDText,
            this.btnSend});
            this.jytCMD.ContextMenuStrip = this.jytMenu;
            this.jytCMD.Location = new System.Drawing.Point(169, 18);
            this.jytCMD.MultiSelect = false;
            this.jytCMD.Name = "jytCMD";
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.jytCMD.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.jytCMD.RowHeadersVisible = false;
            this.jytCMD.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.jytCMD.RowTemplate.Height = 23;
            this.jytCMD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jytCMD.Size = new System.Drawing.Size(374, 151);
            this.jytCMD.TabIndex = 60;
            this.jytCMD.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.jytCMD_CellContentClick);
            // 
            // IsAutoSend
            // 
            this.IsAutoSend.HeaderText = "循环";
            this.IsAutoSend.Name = "IsAutoSend";
            this.IsAutoSend.Width = 60;
            // 
            // CMDText
            // 
            this.CMDText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CMDText.DataPropertyName = "Text";
            this.CMDText.HeaderText = "命令";
            this.CMDText.Name = "CMDText";
            this.CMDText.ReadOnly = true;
            // 
            // btnSend
            // 
            this.btnSend.HeaderText = "发送";
            this.btnSend.Name = "btnSend";
            this.btnSend.ReadOnly = true;
            this.btnSend.Text = "发送";
            // 
            // jytCom
            // 
            this.jytCom.Location = new System.Drawing.Point(11, 181);
            this.jytCom.Name = "jytCom";
            this.jytCom.Size = new System.Drawing.Size(144, 33);
            this.jytCom.TabIndex = 59;
            this.jytCom.Text = "启动监听";
            this.jytCom.UseVisualStyleBackColor = true;
            this.jytCom.Click += new System.EventHandler(this.jytCom_Click);
            // 
            // jytServerIP
            // 
            this.jytServerIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jytServerIP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.jytServerIP.FormattingEnabled = true;
            this.jytServerIP.Items.AddRange(new object[] {
            "Any"});
            this.jytServerIP.Location = new System.Drawing.Point(49, 19);
            this.jytServerIP.Name = "jytServerIP";
            this.jytServerIP.Size = new System.Drawing.Size(106, 22);
            this.jytServerIP.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(10, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 57;
            this.label2.Text = "端口";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 56;
            this.label1.Text = "本地";
            // 
            // jytAutoSend
            // 
            this.jytAutoSend.Location = new System.Drawing.Point(169, 181);
            this.jytAutoSend.Name = "jytAutoSend";
            this.jytAutoSend.Size = new System.Drawing.Size(91, 33);
            this.jytAutoSend.TabIndex = 61;
            this.jytAutoSend.Text = "循环发送";
            this.jytAutoSend.UseVisualStyleBackColor = true;
            this.jytAutoSend.Click += new System.EventHandler(this.jytAutoSend_Click);
            // 
            // jytConn
            // 
            this.jytConn.ContextMenuStrip = this.contextMenuStrip1;
            this.jytConn.DisplayMember = "Name";
            this.jytConn.FormattingEnabled = true;
            this.jytConn.ItemHeight = 12;
            this.jytConn.Location = new System.Drawing.Point(13, 81);
            this.jytConn.Name = "jytConn";
            this.jytConn.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.jytConn.Size = new System.Drawing.Size(143, 88);
            this.jytConn.TabIndex = 73;
            // 
            // jytUdpServerFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 603);
            this.Controls.Add(this.jytConn);
            this.Controls.Add(this.jytServerPort);
            this.Controls.Add(this.jytCmdTxt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.jytGB2312);
            this.Controls.Add(this.jytUTF8);
            this.Controls.Add(this.jytASCII);
            this.Controls.Add(this.jytHex);
            this.Controls.Add(this.jytAutoLine);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.jytDelay);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.jyttxtData);
            this.Controls.Add(this.jytCMD);
            this.Controls.Add(this.jytCom);
            this.Controls.Add(this.jytServerIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.jytAutoSend);
            this.Name = "jytUdpServerFrom";
            this.Text = "jytUdpServerFrom";
            this.Load += new System.EventHandler(this.jytUdpServerFrom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.jytServerPort)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.jytMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jytDelay)).EndInit();
            this.jytMenuClear.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jytCMD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown jytServerPort;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 断开连接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MS_Edit;
        private System.Windows.Forms.ToolStripMenuItem MS_Add;
        private System.Windows.Forms.TextBox jytCmdTxt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip jytMenu;
        private System.Windows.Forms.ToolStripMenuItem MS_Delete;
        private System.Windows.Forms.RadioButton jytGB2312;
        private System.Windows.Forms.RadioButton jytUTF8;
        private System.Windows.Forms.RadioButton jytASCII;
        private System.Windows.Forms.RadioButton jytHex;
        private System.Windows.Forms.CheckBox jytAutoLine;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown jytDelay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox jyttxtData;
        private System.Windows.Forms.ContextMenuStrip jytMenuClear;
        private System.Windows.Forms.ToolStripMenuItem jytOutTxtClear;
        private System.Windows.Forms.DataGridView jytCMD;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsAutoSend;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMDText;
        private System.Windows.Forms.DataGridViewButtonColumn btnSend;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button jytCom;
        private System.Windows.Forms.ComboBox jytServerIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button jytAutoSend;
        private System.Windows.Forms.ListBox jytConn;
    }
}