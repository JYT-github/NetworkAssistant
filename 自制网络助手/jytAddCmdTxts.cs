using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 自制网络助手
{
    public partial class jytAddCmdTxts : Form
    {
        public jytAddCmdTxts(string value)
        {
            InitializeComponent();
            //获取 要修改的内容 将内容设置到当前窗口的文本框中
            TextBoxValue = value;
        }
        ///文本框内容存放
        public string TextBoxValue
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        //点击确认
        private void button1_Click(object sender, EventArgs e)
        {
            
            this.DialogResult = DialogResult.OK;
        }
        //点击取消
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
