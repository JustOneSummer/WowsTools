using System;
using System.Drawing;
using System.Windows.Forms;
using WowsTools.Properties;

namespace WowsTools
{
    /// <summary>
    /// 委托
    /// </summary>
    public delegate void SaveReloadDataGridViewTemplateSelectEvent();

    public partial class DataGridViewTemplateSelect : Form
    {
        /// <summary>
        /// 事件
        /// </summary>
        public event SaveReloadDataGridViewTemplateSelectEvent SaveReloadEvent;
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

        private void DataGridViewTemplateSelect_Load(object sender, EventArgs e)
        {
            Color color = Color.Green;
            if (Settings.Default.DataGridViewTemplate == 0)
            {
                this.button1.BackColor = color;
            }
            else
            {
                this.button2.BackColor = color;
            }
        }
    }
}
