using System;
using System.Windows.Forms;
using WowsTools.Properties;

namespace WowsTools
{
    public partial class PathHome : Form
    {
        public PathHome()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 选择目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dilog = new FolderBrowserDialog();
            dilog.Description = "请选择游戏根目录";
            DialogResult dialogResult = dilog.ShowDialog();
            if (dialogResult == DialogResult.OK || dialogResult == DialogResult.Yes)
            {
                textBox1.Text = dilog.SelectedPath;
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Settings.Default.GameHomePath = textBox1.Text + "\\";
            Settings.Default.Save();
            this.Close();
        }

        private void PathHome_Load(object sender, EventArgs e)
        {
            textBox1.Text = Settings.Default.GameHomePath;
        }
    }
}
