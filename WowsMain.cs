using System;
using System.Windows.Forms;
using WowsTools.api;

namespace WowsTools
{
    public partial class WowsMain : Form
    {
        public WowsMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 关于界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuanYuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("yuyuko战舰世界助手工具箱\r\n开发者Q群：872725671\r\nQQ频道：yuyuko助手");
        }

        private void WowsMain_Load(object sender, EventArgs e)
        {
            //WowsServer server;
            //WowsServer.SERVER.TryGetValue("asia", out server);
            //long id= WowsAccount.AccountId(server, "JustOneSummer");
            //Console.WriteLine(id);
            this.dataGridViewOne.RowHeadersVisible = false;
            this.dataGridViewOne.Columns.Add("clan", "军团");
            this.dataGridViewOne.Columns.Add("userName", "玩家");
            this.dataGridViewOne.Columns.Add("userName", "总胜率");
            this.dataGridViewOne.Columns.Add("level", "等级");
            //this.dataGridViewOne.Columns.Add("shipType", "战舰类型");
            this.dataGridViewOne.Columns.Add("shipName", "名称");
            this.dataGridViewOne.Columns.Add("shipWins", "场次");
            this.dataGridViewOne.Columns.Add("shipWins", "胜率");
            this.dataGridViewOne.Columns.Add("shipWins", "场均");
        }
    }
}
