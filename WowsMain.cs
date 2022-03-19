using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using WowsTools.api;
using WowsTools.model;
using WowsTools.Properties;
using WowsTools.service;
using WowsTools.template;
using WowsTools.utils;

namespace WowsTools
{
    public partial class WowsMain : Form
    {
        public WowsMain()
        {
            //1、设置窗体的双缓冲
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            InitializeComponent();

            //2、利用反射设置DataGridView的双缓冲
            Type dgvType = this.dataGridViewOne.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(this.dataGridViewOne, true, null);
        }
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string VERSION = "0.0.7";
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
            this.dataGridViewOne.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dataGridViewOne.Columns.Add("userNameOne", "玩家");
            this.dataGridViewOne.Columns.Add("BattlesOneuserWinsOne", "场次/胜率");
            this.dataGridViewOne.Columns.Add("levelOneShipNameOne", "场均/名称");
            this.dataGridViewOne.Columns.Add("shipBattlesOneShipWinsOne", "场次/胜率");
            this.dataGridViewOne.Columns.Add("ShipPrOne", "评分");
            this.dataGridViewOne.Columns["ShipPrOne"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewOne.Columns["shipBattlesOneShipWinsOne"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewOne.Columns["levelOneShipNameOne"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewOne.Columns["BattlesOneuserWinsOne"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewOne.Columns["userNameOne"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dataGridViewOne.Columns["ShipPrOne"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewOne.Columns["shipBattlesOneShipWinsOne"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewOne.Columns["levelOneShipNameOne"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewOne.Columns["BattlesOneuserWinsOne"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewOne.Columns["userNameOne"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dataGridViewOne.Columns.Add("AB", "A/B");
            this.dataGridViewOne.Columns["AB"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dataGridViewOne.Columns.Add("ShipPrTwo", "评分");
            this.dataGridViewOne.Columns.Add("shipBattlesOneShipWinsTwo", "场次/胜率");
            this.dataGridViewOne.Columns.Add("levelOneShipNameTwo", "场均/名称");
            this.dataGridViewOne.Columns.Add("BattlesOneuserWinsTwo", "场次/胜率");
            this.dataGridViewOne.Columns.Add("userNameTwo", "玩家");
            this.dataGridViewOne.Columns["ShipPrTwo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewOne.Columns["shipBattlesOneShipWinsTwo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewOne.Columns["levelOneShipNameTwo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewOne.Columns["BattlesOneuserWinsTwo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewOne.Columns["userNameTwo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //this.dataGridViewOne.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dataGridViewOne.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewOne.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.dataGridViewOne.AllowUserToAddRows = false;
            this.dataGridViewOne.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOne.ClearSelection();
            this.dataGridViewOne.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            log.Info("初始化 版本=" + VERSION);
            LoadGameHome();
            ShipUtils.Get(0, true);
            ShipPrUtils.Get(0, true);
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
                    if (ver - localV >= 5 && localV > 2)
                    {
                        MessageBox.Show("版本过低！！！\r\n请加Q群872725671获取最新版本,程序将自动退出运行...");
                        System.Diagnostics.Process.GetProcessById(System.Diagnostics.Process.GetCurrentProcess().Id).Kill();
                    }
                    else
                    {
                        MessageBox.Show("发现新版本，请点击关于加Q群872725671获取最新版本!!!");
                    }
                }
            }
            catch (Exception e)
            {
                log.Error("请求版本信息出错！", e);
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
            try
            {
                if (UPDATE)
                {
                    UPDATE = false;
                    CheckUpdate();
                }
                //加载游戏进程信息
                string jsonFilePath = InitialUtils.GetReplayPath();
                if (File.Exists(jsonFilePath))
                {
                    if (GAME_RUN)
                    {
                        GAME_RUN = false;
                        this.OptonsReAnalyzeToolStripMenuItem.Enabled = false;
                        log.Info("游戏replays路径:" + jsonFilePath);
                        this.labelStatusInfo.Text = "加载对局信息中...";
                        ThreadPool.QueueUserWorkItem(new WaitCallback(GameInfo), null);
                    }
                }
                else
                {
                    InitialUtils.GetHome();
                    GAME_RUN = true;
                }
            }
            catch (Exception ex)
            {
                this.OptonsReAnalyzeToolStripMenuItem.Enabled = true;
                log.Error("定时任务出现异常！", ex);
                MessageBox.Show("定时任务出现异常！" + ex.Message);
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
            int gameCount = dataList.Count();
            int i = 0;
            int serverCount = "cn".Equals(gameServer) ? 2 : 8;
            while (true)
            {
                if (i < dataList.Count && ThreadCount() < serverCount)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(LoadGameInfo), dataList[i]);
                    i++;

                }
                else
                {
                    if (GAME_INFO_LIST.Count >= gameCount)
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
                    log.Error("获取对局信息错误！", e);
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
                this.labelStatusInfo.Text = "开始渲染对局数据";
                this.dataGridViewOne.Rows.Clear();

                GameInfoData gameInfoData = PvpService.GameInfoData(server, GAME_INFO_LIST);

                this.dataGridViewOne.Rows.Add(DataGridViewTemplate.AVG(this.dataGridViewOne, server, gameInfoData));
                //排序
                var linqOne = from game in gameInfoData.TeamOneList orderby game.GameAccountShipInfo.ShipTypeNumber, game.GameAccountShipInfo.ShipLevel descending select game;
                gameInfoData.TeamOneList = linqOne.ToList();

                var linqTwo = from game in gameInfoData.TeamTwoList orderby game.GameAccountShipInfo.ShipTypeNumber, game.GameAccountShipInfo.ShipLevel descending select game;
                gameInfoData.TeamTwoList = linqTwo.ToList();

                int len = gameInfoData.TeamOneList.Count > gameInfoData.TeamTwoList.Count ? gameInfoData.TeamOneList.Count : gameInfoData.TeamTwoList.Count;
                for (int i = 0; i < len; i++)
                {
                    this.dataGridViewOne.Rows.Add(DataGridViewTemplate.Template(i, this.dataGridViewOne, gameInfoData));
                }
                LoadDataGridViewWeight();
                this.OptonsReAnalyzeToolStripMenuItem.Enabled = true;
                this.labelStatusInfo.Text = "对局数据渲染结束";
            })));
        }

        /// <summary>
        /// 获取游戏路径
        /// </summary>
        private void LoadGameHome()
        {
            InitialUtils.InitExe();
            if (!string.IsNullOrEmpty(InitialUtils.GetHome()))
            {
                log.Info("游戏路径：" + InitialUtils.GetHome());
                this.labelGamePath.Text = "已识别游戏路径";
                this.labelGamePath.ForeColor = Color.Green;
            }
            else
            {
                this.labelGamePath.Text = "未识别游戏路径";
                this.labelGamePath.ForeColor = Color.Red;
            }
        }

        /// <summary>
        /// 界面行宽
        /// </summary>
        private void LoadDataGridViewWeight()
        {
            this.dataGridViewOne.Columns[0].FillWeight = 30;
            this.dataGridViewOne.Columns[1].FillWeight = 11;
            this.dataGridViewOne.Columns[2].FillWeight = 18;
            this.dataGridViewOne.Columns[3].FillWeight = 11;
            this.dataGridViewOne.Columns[4].FillWeight = 9;

            this.dataGridViewOne.Columns[5].FillWeight = 5;

            this.dataGridViewOne.Columns[6].FillWeight = 9;
            this.dataGridViewOne.Columns[7].FillWeight = 11;
            this.dataGridViewOne.Columns[8].FillWeight = 18;
            this.dataGridViewOne.Columns[9].FillWeight = 11;
            this.dataGridViewOne.Columns[10].FillWeight = 30;
            for (int i = 0; i < this.dataGridViewOne.Columns.Count; i++)
            {
                this.dataGridViewOne.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                this.dataGridViewOne.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            for (int i = 0; i < this.dataGridViewOne.Rows.Count; i++)
            {
                this.dataGridViewOne.Rows[i].Height = 55;
                if (i == 0)
                {
                    this.dataGridViewOne.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(Convert.ToInt32("ffF8F8FF", 16));
                }
            }
        }

        /// <summary>
        /// 选择渲染模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColoursTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewTemplateSelect select = new DataGridViewTemplateSelect();
            select.SaveReloadEvent += new SaveReloadDataGridViewTemplateSelectEvent(DataGridViewTemplateSelectMethod);
            select.ShowDialog();
        }

        /// <summary>
        /// 保存模板回调
        /// </summary>
        private void DataGridViewTemplateSelectMethod()
        {
            OptionsLoadViewToolStripMenuItemToolStripMenuItem_Click(null, null);
        }

        /// <summary>
        /// 重新渲染
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptionsLoadViewToolStripMenuItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WowsServer != null)
            {
                DataViewLoad(WowsServer);
            }
        }

        /// <summary>
        /// 重新解析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptonsReAnalyzeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("是否要重置解析缓存？", "重置", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                Settings.Default.GameHomePath = "N/A";
                Settings.Default.Save();
                LoadGameHome();
                ShipUtils.Get(0, true);
                ShipPrUtils.Get(0, true);
                UPDATE = true;
                GAME_RUN = true;
                MessageBox.Show("刷新成功");
            }
        }

        private void ReBlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 1500;
            this.Height = 836;
        }

        private void replaysFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string paht = @"" + InitialUtils.GetHome() + "replays";
            System.Diagnostics.Process.Start("explorer.exe", paht);
        }

        private void modsFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string paht = @"" + Settings.Default.GameVersionHome + "res_mods";
            System.Diagnostics.Process.Start("explorer.exe", paht);
        }

        /// <summary>
        /// 评分颜色设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrBackColorSettings settings = new PrBackColorSettings();
            settings.SaveReloadEvent += new SaveReloadPrBackColorSettingsEvent(DataGridViewTemplateSelectMethod);
            settings.ShowDialog();
        }

        private void ReloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("是否要重置设置缓存？", "重置", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                Settings.Default.Reset();
                this.labelGamePath.Text = "未识别游戏路径";
                this.labelGamePath.ForeColor = Color.Red;
                DataGridViewTemplateSelectMethod();
                LoadGameHome();
                UPDATE = true;
                GAME_RUN = true;
                MessageBox.Show("重置成功");
            }
        }

        private void LogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string paht = @"" + System.Environment.CurrentDirectory + "/logs";
            System.Diagnostics.Process.Start("explorer.exe", paht);
        }
    }
}
