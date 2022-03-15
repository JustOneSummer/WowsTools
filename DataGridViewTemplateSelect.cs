using System;
using System.Windows.Forms;
using WowsTools.Properties;

namespace WowsTools
{
    /// <summary>
    /// 委托
    /// </summary>
    public delegate void SaveReloadEvent();

    public partial class DataGridViewTemplateSelect : Form
    {
        /// <summary>
        /// 事件
        /// </summary>
        public event SaveReloadEvent SaveReloadEvent;
        public DataGridViewTemplateSelect()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings.Default.DataGridViewTemplate = 0;
            Settings.Default.Save();
            this.Close();
            //回调
            SaveReloadEvent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Settings.Default.DataGridViewTemplate = 1;
            Settings.Default.Save();
            this.Close();
            //回调
            SaveReloadEvent();
        }
    }
}
