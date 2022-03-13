using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using WowsTools.api;
using WowsTools.model;
using WowsTools.service;
using WowsTools.utils;

namespace WowsTools
{
    public partial class WowsMain : Form
    {
        public WowsMain()
        {
            InitializeComponent();
        }
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string VERSION = "0.0.2";
        private static bool UPDATE = true;
        private static bool GAME_RUN = true;

        private static WowsServer WowsServer = null;
        private static List<GameAccountInfoData> GAME_INFO_LIST = new List<GameAccountInfoData>();

        /// <summary>
        /// 关于界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuanYuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Author author = new Author();
            author.ShowDialog();
        }

        private void WowsMain_Load(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Info("当前平台的 .net framework 信息：" + System.Environment.Version.ToString());
            log.Info("正在运行的 .net framework 信息：" + RuntimeInformation.FrameworkDescription);
            this.dataGridViewOne.RowHeadersVisible = false;
            //this.dataGridViewOne.Columns.Add("clan", "军团");
            this.dataGridViewOne.Columns.Add("userName", "玩家");
            this.dataGridViewOne.Columns.Add("Battles", "场次");
            this.dataGridViewOne.Columns.Add("userWins", "胜率");
            this.dataGridViewOne.Columns.Add("level", "lv");
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
            this.dataGridViewTwo.Columns.Add("level", "lv");
            this.dataGridViewTwo.Columns.Add("userWins", "胜率");
            this.dataGridViewTwo.Columns.Add("Battles", "场次");
            //this.dataGridViewTwo.Columns.Add("clan", "军团");
            this.dataGridViewTwo.Columns.Add("userName", "玩家");
            this.dataGridViewTwo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTwo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTwo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTwo.ClearSelection();
            log.Info("初始化 版本=" + VERSION);
            log.Info("游戏路径：" + InitialUtils.wowsExeHomePath());
            ShipUtils.Get(0, true);
            ShipPrUtils.Get(0, true);
        }

        private void dataGridViewTwo_SelectionChanged(object sender, EventArgs e)
        {
            this.dataGridViewTwo.ClearSelection();
        }

        private void dataGridViewOne_SelectionChanged(object sender, EventArgs e)
        {
            this.dataGridViewOne.ClearSelection();
        }

        public void CheckUpdate()
        {
            try
            {
                int localV = int.Parse(VERSION.Replace(".", ""));
                string newV = HttpUtils.GetVersion();
                log.Info("检查版本 新版本=" + newV);
                int ver = int.Parse(newV.Replace(".", ""));
                if (ver > localV)
                {
                    MessageBox.Show("发现新版本，请点击关于加群获取最新版本!!!");
                }
            }
            catch (Exception e)
            {
                log.Error("请求版本信息出错！" + e.Message);
                MessageBox.Show("请求版本信息出错！如果开了代理请关闭全局代理...");
            }
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
            //加载游戏进程信息
            string jsonFilePath = InitialUtils.ReplaysPath();
            if (!string.IsNullOrEmpty(InitialUtils.wowsExeHomePath()) && File.Exists(jsonFilePath))
            {
                if (GAME_RUN)
                {
                    GAME_RUN = false;
                    log.Info("游戏replays路径:" + jsonFilePath);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(GameInfo), null);
                }
            }
            else
            {
                GAME_RUN = true;
            }
        }

        public int ThreadCount()
        {
            int MaxWorkerThreads, miot, AvailableWorkerThreads, aiot;
            //获得最大的线程数量  
            ThreadPool.GetMaxThreads(out MaxWorkerThreads, out miot);
            //获得可用的线程数量  
            ThreadPool.GetAvailableThreads(out AvailableWorkerThreads, out aiot);
            return MaxWorkerThreads - AvailableWorkerThreads;
        }

        /// <summary>
        /// 游戏信息
        /// </summary>
        /// <param name="state"></param>
        public void GameInfo(object state)
        {
            GAME_INFO_LIST.Clear();
            string gameServer = InitialUtils.ServerInfo();
            log.Info("所在服务器：" + gameServer);
            WowsServer.SERVER.TryGetValue(gameServer, out WowsServer);
            List<GameAccountInfoData> dataList = PvpService.ReadReplays();
            log.Info("对局用户数量：" + dataList.Count);
            int i = 0;
            while (true)
            {
                if (i < dataList.Count)
                {
                    if (ThreadCount() < 8)
                    {
                        ThreadPool.QueueUserWorkItem(new WaitCallback(LoadGameInfo), dataList[i]);
                        i++;
                    }
                }
                else
                {
                    if (GAME_INFO_LIST.Count >= dataList.Count)
                    {
                        break;
                    }
                }
            }
            DataViewLoad(WowsServer);
        }

        /// <summary>
        /// 加载游戏信息
        /// </summary>
        /// <param name="state"></param>
        public void LoadGameInfo(object state)
        {
            if (WowsServer != null)
            {
                try
                {
                    GAME_INFO_LIST.Add(PvpService.AccountInfo(WowsServer, (GameAccountInfoData)state));
                }
                catch (Exception e)
                {
                    log.Error("获取对局信息错误！" + e.Message);
                }
            }
        }

        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="server"></param>
        private void DataViewLoad(WowsServer server)
        {
            Invoke((new Action(() =>
            {
                this.dataGridViewOne.Rows.Clear();
                this.dataGridViewTwo.Rows.Clear();
                this.ServerLable.Text = server.ServerName;
                GameInfoData gameInfoData = PvpService.GameInfoData(server, GAME_INFO_LIST);

                this.labelWinsA.Text = "平均胜率：" + (gameInfoData.TeamOneWins / gameInfoData.TeamOneCount).ToString("f2") + "%";
                this.labelWinsB.Text = "平均胜率：" + (gameInfoData.TeamTwoWins / gameInfoData.TeamTwoCount).ToString("f2") + "%";
                //排序
                gameInfoData.TeamOneList.Sort((l, r) => l.GameAccountShipInfo.ShipTypeNumber.CompareTo(r.GameAccountShipInfo.ShipTypeNumber));
                gameInfoData.TeamTwoList.Sort((l, r) => l.GameAccountShipInfo.ShipTypeNumber.CompareTo(r.GameAccountShipInfo.ShipTypeNumber));
                string na = "N/A";
                foreach (var data in gameInfoData.TeamOneList)
                {
                    GameAccountShipInfoData shipData = data.GameAccountShipInfo;
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.dataGridViewOne);
                    row.Cells[0].Value = data.AccountName;
                    row.Cells[1].Value = data.Battles;

                    row.Cells[2].Value = data.Hide ? na : data.GameWins().ToString("f2") + "%";
                    row.Cells[2].Style.ForeColor = ColorUtils.WinsColor(data.GameWins());

                    row.Cells[3].Value = ShipUtils.LevelInfo(shipData.ShipLevel);
                    row.Cells[4].Value = data.Hide ? na : shipData.ShipName;
                    row.Cells[5].Value = data.Hide ? na : shipData.Battles.ToString();
                    row.Cells[6].Value = data.Hide ? na : shipData.GameDamage().ToString();

                    row.Cells[7].Value = data.Hide ? na : shipData.GameWins().ToString("f2") + "%"; ;
                    row.Cells[7].Style.ForeColor = ColorUtils.WinsColor(shipData.GameWins());

                    row.Cells[8].Value = data.Hide ? na : shipData.Pr.ToString();
                    row.Cells[8].Style.ForeColor = ColorUtils.PrColor(shipData.Pr);
                    this.dataGridViewOne.Rows.Add(row);

                }

                foreach (var data in gameInfoData.TeamTwoList)
                {
                    GameAccountShipInfoData shipData = data.GameAccountShipInfo;
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.dataGridViewOne);
                    row.Cells[8].Value = data.AccountName;
                    row.Cells[7].Value = data.Battles;

                    row.Cells[6].Value = data.Hide ? na : data.GameWins().ToString("f2") + "%";
                    row.Cells[6].Style.ForeColor = ColorUtils.WinsColor(data.GameWins());

                    row.Cells[5].Value = ShipUtils.LevelInfo(shipData.ShipLevel);
                    row.Cells[4].Value = data.Hide ? na : shipData.ShipName;
                    row.Cells[3].Value = data.Hide ? na : shipData.Battles.ToString();
                    row.Cells[2].Value = data.Hide ? na : shipData.GameDamage().ToString();

                    row.Cells[1].Value = data.Hide ? na : shipData.GameWins().ToString("f2") + "%"; ;
                    row.Cells[1].Style.ForeColor = ColorUtils.WinsColor(shipData.GameWins());

                    row.Cells[0].Value = data.Hide ? na : shipData.Pr.ToString();
                    row.Cells[0].Style.ForeColor = ColorUtils.PrColor(shipData.Pr);
                    this.dataGridViewTwo.Rows.Add(row);
                }

                for (int j = 0; j < 9; j++)
                {
                    this.dataGridViewOne.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.dataGridViewOne.Columns[j].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dataGridViewTwo.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.dataGridViewTwo.Columns[j].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                this.dataGridViewOne.Columns[0].FillWeight = 26;
                this.dataGridViewOne.Columns[1].FillWeight = 9;
                this.dataGridViewOne.Columns[2].FillWeight = 10;
                this.dataGridViewOne.Columns[3].FillWeight = 6;
                this.dataGridViewOne.Columns[4].FillWeight = 12;
                this.dataGridViewOne.Columns[5].FillWeight = 9;
                this.dataGridViewOne.Columns[6].FillWeight = 9;
                this.dataGridViewOne.Columns[7].FillWeight = 10;
                this.dataGridViewOne.Columns[8].FillWeight = 9;

                this.dataGridViewOne.Columns[8].FillWeight = 26;
                this.dataGridViewOne.Columns[7].FillWeight = 9;
                this.dataGridViewOne.Columns[6].FillWeight = 10;
                this.dataGridViewOne.Columns[5].FillWeight = 6;
                this.dataGridViewOne.Columns[4].FillWeight = 12;
                this.dataGridViewOne.Columns[3].FillWeight = 9;
                this.dataGridViewOne.Columns[2].FillWeight = 9;
                this.dataGridViewOne.Columns[1].FillWeight = 10;
                this.dataGridViewOne.Columns[0].FillWeight = 9;
            })));
        }

        /// <summary>
        /// 点击时重新加载文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShipUtils.Get(0, true);
            ShipPrUtils.Get(0, true);
            UPDATE = true;
            GAME_RUN = true;
        }
    }
}
