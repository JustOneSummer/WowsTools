using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WowsTools.model;
using WowsTools.utils;

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
            //this.dataGridViewOne.Columns.Add("clan", "军团");
            this.dataGridViewOne.Columns.Add("userName", "玩家");
            this.dataGridViewOne.Columns.Add("userWins", "总胜率");
            this.dataGridViewOne.Columns.Add("level", "等级");
            this.dataGridViewOne.Columns.Add("shipName", "名称");
            this.dataGridViewOne.Columns.Add("shipBattles", "场次");
            this.dataGridViewOne.Columns.Add("shipDamage", "场均");
            this.dataGridViewOne.Columns.Add("shipWins", "胜率");
            this.dataGridViewOne.Columns.Add("shipPr", "评分");
            this.dataGridViewOne.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewOne.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dataGridViewTwo.RowHeadersVisible = false;
            this.dataGridViewTwo.Columns.Add("shipPr", "评分");
            this.dataGridViewTwo.Columns.Add("shipWins", "胜率");
            this.dataGridViewTwo.Columns.Add("shipDamage", "场均");
            this.dataGridViewTwo.Columns.Add("shipBattles", "场次");
            this.dataGridViewTwo.Columns.Add("shipName", "名称");
            this.dataGridViewTwo.Columns.Add("level", "等级");
            this.dataGridViewTwo.Columns.Add("userWins", "总胜率");
            //this.dataGridViewTwo.Columns.Add("clan", "军团");
            this.dataGridViewTwo.Columns.Add("userName", "玩家");
            this.dataGridViewTwo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTwo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        /// <summary>
        /// 加载游戏信息
        /// </summary>
        private void loadGameInfo()
        {
            //加载游戏进程信息
            string gamePath = InitialUtils.wowsExeHomePath();
            if (!string.IsNullOrEmpty(gamePath))
            {
                //获取所在服务器
                string gameServer = InitialUtils.ServerInfo();
                List<WowsUserData> wowsUserDatas = InitialUtils.getReplaysData();
                if (wowsUserDatas.Count >= 1)
                {
                    //查询用户游戏信息
                    DataViewLoad(wowsUserDatas);
                }
            }
        }

        private void DataViewLoad(List<WowsUserData> wowsUserDatas)
        {
            this.dataGridViewOne.Rows.Clear();
            this.dataGridViewTwo.Rows.Clear();
            int i = 0;
            foreach(var data in wowsUserDatas)
            {
                if (data.relation >= 2)
                {
                    string[] vs = {
                    data.shipPr+"",
                    data.shipWins,
                    data.shipDamage+"",
                    data.shipBattles+"",
                    data.shipName,
                    data.shipLevel,
                    data.wins,
                    data.userName
                    };
                    this.dataGridViewTwo.Rows.Add(vs);
                }
                else
                {
                    string[] vs = {
                    data.userName,
                    data.wins,
                    data.shipLevel,
                    data.shipName,
                    data.shipBattles+"",
                    data.shipDamage+"",
                    data.shipWins,
                    data.shipPr+""
                    };
                    this.dataGridViewOne.Rows.Add(vs);
                }
                for (int j = 0; j < 8; j++)
                {
                    //this.dataGridViewOne.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.dataGridViewOne.Columns[j].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //this.dataGridViewTwo.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.dataGridViewTwo.Columns[j].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                i++;
            }
        }

        /// <summary>
        /// 定时器事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerGameCheck_Tick(object sender, EventArgs e)
        {
            loadGameInfo();
        }
    }
}
