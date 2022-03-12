using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using WowsTools.api;
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

        private const string VERSION = "0.0.1";
        private static bool UPDATE = true;
        private static bool GAME_RUN = true;

        /// <summary>
        /// 关于界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuanYuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("yuyuko战舰世界助手工具箱\r\n开发者Q群：872725671\r\nQQ频道：yuyuko助手");
            Author author = new Author();
            author.ShowDialog();
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
            this.dataGridViewOne.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOne.ClearSelection();

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
            this.dataGridViewTwo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTwo.ClearSelection();
        }

        private void dataGridViewTwo_SelectionChanged(object sender, EventArgs e)
        {
            this.dataGridViewTwo.ClearSelection();
        }

        private void dataGridViewOne_SelectionChanged(object sender, EventArgs e)
        {
            this.dataGridViewOne.ClearSelection();
        }

        /// <summary>
        /// 定时器事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerGameCheck_Tick(object sender, EventArgs e)
        {
            if (UPDATE)
            {
                UPDATE = false;
                CheckUpdate();
            }
            Invoke((new Action(() =>
            {
                //加载游戏进程信息
                string gamePath = InitialUtils.wowsExeHomePath();
                if (!string.IsNullOrEmpty(gamePath))
                {
                    string jsonFilePath = InitialUtils.ReplaysPath();
                    if (File.Exists(jsonFilePath))
                    {
                        if (GAME_RUN)
                        {
                            GAME_RUN = false;
                            ThreadPool.QueueUserWorkItem(new WaitCallback(LoadGameInfo), null);
                        }
                    }
                    else
                    {
                        GAME_RUN = true;
                    }
                }
            })));
        }

        public void LoadGameInfo(object o)
        {
            //获取所在服务器
            string gameServer = InitialUtils.ServerInfo();
            List<WowsUserData> wowsUserDatas = InitialUtils.getReplaysData();
            if (wowsUserDatas.Count >= 1)
            {
                WowsServer server;
                WowsServer.SERVER.TryGetValue(gameServer, out server);
                Dictionary<string, WowsUserInfo> map = WowsAccount.GameInfo(server, WowsAccount.AccountId(server, wowsUserDatas));

                //区分团队
                List<WowsUserData> a = new List<WowsUserData>();
                List<WowsUserData> b = new List<WowsUserData>();
                double winsA = 0;
                double winsB = 0;
                int CA = 0;
                int CB = 0;
                foreach (var item in wowsUserDatas)
                {
                    bool shiFouA = true;
                    WowsUserInfo info;
                    map.TryGetValue(item.userName, out info);
                    item.accountId = info.AccountInfo.AccountId;
                    //船只信息
                    WowsShipData shipData = WowsAccount.GameShip(server, item);
                    ShipUtils shipUtils = ShipUtils.Get(shipData.shipId,false);
                    item.shipName = string.IsNullOrEmpty(shipUtils.ship_name_cn) ? shipUtils.name : shipUtils.ship_name_cn;
                    item.shipLevel = ShipUtils.LevelInfo(shipUtils.tier);
                    item.shipTypeNumber = ShipUtils.ShipType(shipUtils.ship_type);
                    //PR
                    ShipPrUtils shipPrUtils = ShipPrUtils.Get(shipData.shipId, false);
                    item.shipPr =  ShipPrUtils.Pr(shipData, shipPrUtils);
                    if (item.relation >= 2)
                    {
                        shiFouA = false;
                        winsB += info.GameWins();
                    }
                    else
                    {
                        winsA += info.GameWins();
                    }

                    if (info.Battles >= 0)
                    {
                        if (shiFouA)
                        {
                            CA++;
                        }
                        else
                        {
                            CB++;
                        }
                        item.shipBattles = shipData.Battles.ToString();
                        item.shipDamage = shipData.GameDamage().ToString();
                        item.shipWins = shipData.GameWins().ToString("f2") + "%";
                        item.wins = info.GameWins().ToString("f2") + "%";
                    }
                    if (shiFouA)
                    {
                        a.Add(item);
                    }
                    else
                    {
                        b.Add(item);
                    }
                }
                DataViewLoad(a, winsA,CA, b, winsB,CB);
            }
        }

        private void DataViewLoad(List<WowsUserData> teamA, double winsA,int countA, List<WowsUserData> teamB, double winsB, int countB)
        {
            Invoke((new Action(() =>
            {
                //排序
                teamA.Sort((l, r) => l.shipTypeNumber.CompareTo(r.shipTypeNumber));
                teamB.Sort((l, r) => l.shipTypeNumber.CompareTo(r.shipTypeNumber));
                this.dataGridViewOne.Rows.Clear();
                this.dataGridViewTwo.Rows.Clear();
                int i = 0;
                this.labelWinsA.Text = "平均胜率：" + (winsA / countA).ToString("f2") + "%";
                this.labelWinsB.Text = "平均胜率：" + (winsB / countB).ToString("f2") + "%";

                foreach (var data in teamA)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.dataGridViewOne);
                    row.Cells[0].Value = data.userName;
                    row.Cells[1].Value = data.wins;
                    row.Cells[1].Style.ForeColor = ColorUtils.WinsColor(data.wins);
                    row.Cells[2].Value = data.shipLevel;
                    row.Cells[3].Value = data.shipName;
                    row.Cells[4].Value = data.shipBattles;
                    row.Cells[5].Value = data.shipDamage;

                    row.Cells[6].Value = data.shipWins;
                    row.Cells[6].Style.ForeColor = ColorUtils.WinsColor(data.wins);

                    row.Cells[7].Value = data.shipPr;
                    row.Cells[7].Style.ForeColor = ColorUtils.PrColor(data.shipPr);
                    this.dataGridViewOne.Rows.Add(row);

                }
                foreach (var data in teamB)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.dataGridViewOne);
                    row.Cells[7].Value = data.userName;
                    row.Cells[6].Value = data.wins;
                    row.Cells[6].Style.ForeColor = ColorUtils.WinsColor(data.wins);
                    row.Cells[5].Value = data.shipLevel;
                    row.Cells[4].Value = data.shipName;
                    row.Cells[3].Value = data.shipBattles;
                    row.Cells[2].Value = data.shipDamage;

                    row.Cells[1].Value = data.shipWins;
                    row.Cells[1].Style.ForeColor = ColorUtils.WinsColor(data.wins);

                    row.Cells[0].Value = data.shipPr;
                    row.Cells[0].Style.ForeColor = ColorUtils.PrColor(data.shipPr);
                    this.dataGridViewTwo.Rows.Add(row);
                }
                for (int j = 0; j < 8; j++)
                {
                    //this.dataGridViewOne.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.dataGridViewOne.Columns[j].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //this.dataGridViewTwo.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.dataGridViewTwo.Columns[j].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                this.dataGridViewOne.Columns[0].FillWeight = 26;
                this.dataGridViewOne.Columns[1].FillWeight = 12;
                this.dataGridViewOne.Columns[2].FillWeight = 9;
                this.dataGridViewOne.Columns[3].FillWeight = 16;

                this.dataGridViewOne.Columns[4].FillWeight = 9;
                this.dataGridViewOne.Columns[5].FillWeight = 10;
                this.dataGridViewOne.Columns[6].FillWeight = 9;
                this.dataGridViewOne.Columns[7].FillWeight = 9;


                this.dataGridViewTwo.Columns[7].FillWeight = 26;
                this.dataGridViewTwo.Columns[6].FillWeight = 12;
                this.dataGridViewTwo.Columns[5].FillWeight = 9;
                this.dataGridViewTwo.Columns[4].FillWeight = 16;

                this.dataGridViewTwo.Columns[3].FillWeight = 9;
                this.dataGridViewTwo.Columns[2].FillWeight = 10;
                this.dataGridViewTwo.Columns[1].FillWeight = 9;
                this.dataGridViewTwo.Columns[0].FillWeight = 9;
                i++;

            })));
        }

        public void CheckUpdate()
        {
            int localV = int.Parse(VERSION.Replace(".",""));

            int ver = int.Parse(HttpUtils.GetVersion().Replace(".", ""));

            if (ver > localV)
            {
                MessageBox.Show("发现新版本，请点击关于加群获取最新版本!!!");
            }
        }
    }
}
