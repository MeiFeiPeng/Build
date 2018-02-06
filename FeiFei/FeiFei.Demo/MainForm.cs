using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeiFei.Demo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        /// <summary>
        /// 生成日志
        /// </summary>
        private void button_Log_Click(object sender, EventArgs e)
        {
            LogHelper.Instance.WriteLog(Log.LogLevel.Info, "我来测试日志输出.");
            MessageBox.Show("日志生成成功,请打开日志目录观察.");
        }

        /// <summary>
        /// 打开日志目录
        /// </summary>
        private void button_LogDir_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"/Log/FeiFei/");
        }
    }
}
