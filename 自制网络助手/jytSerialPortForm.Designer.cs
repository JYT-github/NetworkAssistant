namespace 自制网络助手
{
    partial class jytSerialPortForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.jytComList = new System.Windows.Forms.ComboBox();
            this.jytBaudRate = new System.Windows.Forms.ComboBox();
            this.jytCheckBit = new System.Windows.Forms.ComboBox();
            this.jytDataBits = new System.Windows.Forms.ComboBox();
            this.jytStopBit = new System.Windows.Forms.ComboBox();
            this.jytCom = new System.Windows.Forms.Button();
            this.jytCMD = new System.Windows.Forms.DataGridView();
            this.IsAutoSend = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CMDText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSend = new System.Windows.Forms.DataGridViewButtonColumn();
            this.jytMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MS_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.MS_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.MS_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.label7 = new System.Windows.Forms.Label();
            this.jytDelay = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.jytAutoSend = new System.Windows.Forms.Button();
            this.jyttxtData = new System.Windows.Forms.TextBox();
            this.jytMenuClear = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.jytOutTxtClear = new System.Windows.Forms.ToolStripMenuItem();
            this.jytGB2312 = new System.Windows.Forms.RadioButton();
            this.jytUTF8 = new System.Windows.Forms.RadioButton();
            this.jytASCII = new System.Windows.Forms.RadioButton();
            this.jytHex = new System.Windows.Forms.RadioButton();
            this.jytAutoLine = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.jytCmdTxt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.jytCMD)).BeginInit();
            this.jytMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jytDelay)).BeginInit();
            this.jytMenuClear.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(8, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "波特率";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(8, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "校验位";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(8, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "数据位";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(6, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "停止位";
            // 
            // jytComList
            // 
            this.jytComList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jytComList.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.jytComList.FormattingEnabled = true;
            this.jytComList.Location = new System.Drawing.Point(61, 12);
            this.jytComList.Name = "jytComList";
            this.jytComList.Size = new System.Drawing.Size(95, 22);
            this.jytComList.TabIndex = 5;
            // 
            // jytBaudRate
            // 
            this.jytBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jytBaudRate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.jytBaudRate.FormattingEnabled = true;
            this.jytBaudRate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "43000",
            "56000",
            "57600",
            "115200"});
            this.jytBaudRate.Location = new System.Drawing.Point(61, 44);
            this.jytBaudRate.Name = "jytBaudRate";
            this.jytBaudRate.Size = new System.Drawing.Size(95, 22);
            this.jytBaudRate.TabIndex = 6;
            // 
            // jytCheckBit
            // 
            this.jytCheckBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jytCheckBit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.jytCheckBit.FormattingEnabled = true;
            this.jytCheckBit.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.jytCheckBit.Location = new System.Drawing.Point(61, 77);
            this.jytCheckBit.Name = "jytCheckBit";
            this.jytCheckBit.Size = new System.Drawing.Size(95, 22);
            this.jytCheckBit.TabIndex = 7;
            // 
            // jytDataBits
            // 
            this.jytDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jytDataBits.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.jytDataBits.FormattingEnabled = true;
            this.jytDataBits.Items.AddRange(new object[] {
            "8",
            "7",
            "6"});
            this.jytDataBits.Location = new System.Drawing.Point(61, 109);
            this.jytDataBits.Name = "jytDataBits";
            this.jytDataBits.Size = new System.Drawing.Size(95, 22);
            this.jytDataBits.TabIndex = 8;
            // 
            // jytStopBit
            // 
            this.jytStopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jytStopBit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.jytStopBit.FormattingEnabled = true;
            this.jytStopBit.Items.AddRange(new object[] {
            "1",
            "2"});
            this.jytStopBit.Location = new System.Drawing.Point(61, 141);
            this.jytStopBit.Name = "jytStopBit";
            this.jytStopBit.Size = new System.Drawing.Size(95, 22);
            this.jytStopBit.TabIndex = 9;
            // 
            // jytCom
            // 
            this.jytCom.Enabled = false;
            this.jytCom.Location = new System.Drawing.Point(12, 174);
            this.jytCom.Name = "jytCom";
            this.jytCom.Size = new System.Drawing.Size(144, 33);
            this.jytCom.TabIndex = 10;
            this.jytCom.Text = "打开串口";
            this.jytCom.UseVisualStyleBackColor = true;
            this.jytCom.Click += new System.EventHandler(this.jytCom_Click);
            // 
            // jytCMD
            // 
            this.jytCMD.AllowUserToAddRows = false;
            this.jytCMD.AllowUserToDeleteRows = false;
            this.jytCMD.AllowUserToResizeRows = false;
            this.jytCMD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jytCMD.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.jytCMD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.jytCMD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jytCMD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsAutoSend,
            this.CMDText,
            this.btnSend});
            this.jytCMD.ContextMenuStrip = this.jytMenu;
            this.jytCMD.Location = new System.Drawing.Point(170, 11);
            this.jytCMD.MultiSelect = false;
            this.jytCMD.Name = "jytCMD";
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.jytCMD.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.jytCMD.RowHeadersVisible = false;
            this.jytCMD.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.jytCMD.RowTemplate.Height = 23;
            this.jytCMD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jytCMD.Size = new System.Drawing.Size(419, 151);
            this.jytCMD.TabIndex = 12;
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
            // jytMenu
            // 
            this.jytMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MS_Add,
            this.MS_Edit,
            this.MS_Delete});
            this.jytMenu.Name = "contextMenuStrip1";
            this.jytMenu.Size = new System.Drawing.Size(101, 70);
            // 
            // MS_Add
            // 
            this.MS_Add.Name = "MS_Add";
            this.MS_Add.Size = new System.Drawing.Size(100, 22);
            this.MS_Add.Text = "添加";
            this.MS_Add.Click += new System.EventHandler(this.MS_Add_Click);
            // 
            // MS_Edit
            // 
            this.MS_Edit.Name = "MS_Edit";
            this.MS_Edit.Size = new System.Drawing.Size(100, 22);
            this.MS_Edit.Text = "编辑";
            this.MS_Edit.Click += new System.EventHandler(this.MS_Edit_Click);
            // 
            // MS_Delete
            // 
            this.MS_Delete.Name = "MS_Delete";
            this.MS_Delete.Size = new System.Drawing.Size(100, 22);
            this.MS_Delete.Text = "删除";
            this.MS_Delete.Click += new System.EventHandler(this.MS_Delete_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(400, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "毫秒";
            // 
            // jytDelay
            // 
            this.jytDelay.Location = new System.Drawing.Point(326, 179);
            this.jytDelay.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.jytDelay.Name = "jytDelay";
            this.jytDelay.Size = new System.Drawing.Size(70, 21);
            this.jytDelay.TabIndex = 15;
            this.jytDelay.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(267, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "发送间隔：";
            // 
            // jytAutoSend
            // 
            this.jytAutoSend.Location = new System.Drawing.Point(170, 174);
            this.jytAutoSend.Name = "jytAutoSend";
            this.jytAutoSend.Size = new System.Drawing.Size(91, 33);
            this.jytAutoSend.TabIndex = 13;
            this.jytAutoSend.Text = "循环发送";
            this.jytAutoSend.UseVisualStyleBackColor = true;
            this.jytAutoSend.Click += new System.EventHandler(this.jytAutoSend_Click);
            // 
            // jyttxtData
            // 
            this.jyttxtData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jyttxtData.ContextMenuStrip = this.jytMenuClear;
            this.jyttxtData.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.jyttxtData.Location = new System.Drawing.Point(9, 325);
            this.jyttxtData.MaxLength = 1;
            this.jyttxtData.Multiline = true;
            this.jyttxtData.Name = "jyttxtData";
            this.jyttxtData.ReadOnly = true;
            this.jyttxtData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.jyttxtData.Size = new System.Drawing.Size(580, 255);
            this.jyttxtData.TabIndex = 20;
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
            this.jytOutTxtClear.Click += new System.EventHandler(this.jytOutTxtClear_Click);
            // 
            // jytGB2312
            // 
            this.jytGB2312.AutoSize = true;
            this.jytGB2312.Location = new System.Drawing.Point(80, 267);
            this.jytGB2312.Name = "jytGB2312";
            this.jytGB2312.Size = new System.Drawing.Size(59, 16);
            this.jytGB2312.TabIndex = 27;
            this.jytGB2312.Text = "GB2312";
            this.jytGB2312.UseVisualStyleBackColor = true;
            this.jytGB2312.CheckedChanged += new System.EventHandler(this.jytGB2312_CheckedChanged);
            // 
            // jytUTF8
            // 
            this.jytUTF8.AutoSize = true;
            this.jytUTF8.Location = new System.Drawing.Point(8, 267);
            this.jytUTF8.Name = "jytUTF8";
            this.jytUTF8.Size = new System.Drawing.Size(47, 16);
            this.jytUTF8.TabIndex = 26;
            this.jytUTF8.Text = "UTF8";
            this.jytUTF8.UseVisualStyleBackColor = true;
            this.jytUTF8.CheckedChanged += new System.EventHandler(this.jytUTF8_CheckedChanged);
            // 
            // jytASCII
            // 
            this.jytASCII.AutoSize = true;
            this.jytASCII.Location = new System.Drawing.Point(80, 236);
            this.jytASCII.Name = "jytASCII";
            this.jytASCII.Size = new System.Drawing.Size(53, 16);
            this.jytASCII.TabIndex = 23;
            this.jytASCII.Text = "ASCII";
            this.jytASCII.UseVisualStyleBackColor = true;
            this.jytASCII.CheckedChanged += new System.EventHandler(this.jytASCII_CheckedChanged);
            // 
            // jytHex
            // 
            this.jytHex.AutoSize = true;
            this.jytHex.Checked = true;
            this.jytHex.Location = new System.Drawing.Point(8, 236);
            this.jytHex.Name = "jytHex";
            this.jytHex.Size = new System.Drawing.Size(41, 16);
            this.jytHex.TabIndex = 22;
            this.jytHex.TabStop = true;
            this.jytHex.Text = "Hex";
            this.jytHex.UseVisualStyleBackColor = true;
            this.jytHex.CheckedChanged += new System.EventHandler(this.jytHex_CheckedChanged);
            // 
            // jytAutoLine
            // 
            this.jytAutoLine.AutoSize = true;
            this.jytAutoLine.Location = new System.Drawing.Point(9, 299);
            this.jytAutoLine.Name = "jytAutoLine";
            this.jytAutoLine.Size = new System.Drawing.Size(72, 16);
            this.jytAutoLine.TabIndex = 21;
            this.jytAutoLine.Text = "自动换行";
            this.jytAutoLine.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(168, 290);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "发送";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // jytCmdTxt
            // 
            this.jytCmdTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jytCmdTxt.Location = new System.Drawing.Point(170, 212);
            this.jytCmdTxt.Multiline = true;
            this.jytCmdTxt.Name = "jytCmdTxt";
            this.jytCmdTxt.Size = new System.Drawing.Size(419, 71);
            this.jytCmdTxt.TabIndex = 0;
            // 
            // jytSerialPortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 593);
            this.Controls.Add(this.jytCmdTxt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.jyttxtData);
            this.Controls.Add(this.jytGB2312);
            this.Controls.Add(this.jytUTF8);
            this.Controls.Add(this.jytASCII);
            this.Controls.Add(this.jytHex);
            this.Controls.Add(this.jytAutoLine);
            this.Controls.Add(this.jytCMD);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.jytDelay);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.jytAutoSend);
            this.Controls.Add(this.jytCom);
            this.Controls.Add(this.jytStopBit);
            this.Controls.Add(this.jytDataBits);
            this.Controls.Add(this.jytCheckBit);
            this.Controls.Add(this.jytBaudRate);
            this.Controls.Add(this.jytComList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "jytSerialPortForm";
            this.Text = "jytSerialPort";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.jytSerialPortForm_FormClosing);
            this.Load += new System.EventHandler(this.jytSerialPortForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.jytCMD)).EndInit();
            this.jytMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jytDelay)).EndInit();
            this.jytMenuClear.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox jytComList;
        private System.Windows.Forms.ComboBox jytBaudRate;
        private System.Windows.Forms.ComboBox jytCheckBit;
        private System.Windows.Forms.ComboBox jytDataBits;
        private System.Windows.Forms.ComboBox jytStopBit;
        private System.Windows.Forms.Button jytCom;
        private System.Windows.Forms.DataGridView jytCMD;
        private System.Windows.Forms.ContextMenuStrip jytMenu;
        private System.Windows.Forms.ToolStripMenuItem MS_Add;
        private System.Windows.Forms.ToolStripMenuItem MS_Edit;
        private System.Windows.Forms.ToolStripMenuItem MS_Delete;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown jytDelay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button jytAutoSend;
        private System.Windows.Forms.TextBox jyttxtData;
        private System.Windows.Forms.RadioButton jytGB2312;
        private System.Windows.Forms.RadioButton jytUTF8;
        private System.Windows.Forms.RadioButton jytASCII;
        private System.Windows.Forms.RadioButton jytHex;
        private System.Windows.Forms.CheckBox jytAutoLine;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox jytCmdTxt;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsAutoSend;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMDText;
        private System.Windows.Forms.DataGridViewButtonColumn btnSend;
        private System.Windows.Forms.ContextMenuStrip jytMenuClear;
        private System.Windows.Forms.ToolStripMenuItem jytOutTxtClear;
    }
}