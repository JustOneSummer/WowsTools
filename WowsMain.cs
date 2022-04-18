using HtmlAgilityPack;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Web;
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
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(this.dataGridViewOne, true, null);
        }
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string VERSION = "0.1.0";
        private static bool UPDATE = true;
        private static bool GAME_RUN = true;

        private static WowsServer WowsServer = null;
        private static List<GameAccountInfoData> GAME_INFO_LIST = new List<GameAccountInfoData>();

        private void WowsMain_Load(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Info("正在运行的 .net framework 信息：" + RuntimeInformation.FrameworkDescription);
            this.dataGridViewOne = DataGridViewTemplateInitialLoad.Load(this.dataGridViewOne);
            log.Info("初始化 版本=" + VERSION);
            log.Info("windows version = " + Program.OS_VERSION);
            if (Program.OS_VERSION_WIN7)
            {
                string url = "https://wowsgame.cn/zh-cn/community/accounts/search/?search=" + HttpUtility.UrlEncode("西行寺雨季") + "&pjax=1";
                var htmlWebHomeSelect = new HtmlWeb();
                htmlWebHomeSelect.Load(url);
                log.Info("加载信息成功...");
            }
            LoadGameHome();
            ShipUtils.Get(0, true);
            ShipPrUtils.Get(0, true);
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
                        GAME_INFO_LIST.Clear();
                        this.dataGridViewOne.Rows.Clear();
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

        /// <summary>
        /// 线程数量
        /// </summary>
        /// <returns></returns>
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
            string gameServer = InitialUtils.ServerInfo();
            log.Info("所在服务器：" + gameServer);
            WowsServer.SERVER.TryGetValue(gameServer, out WowsServer);
            List<GameAccountInfoData> dataList = PvpService.ReadReplays();
            log.Info("对局用户数量：" + dataList.Count);
            int gameCount = dataList.Count();
            int i = 0;
            int serverCount = "cn".Equals(gameServer) ? 2 : InitialUtils.CpuProcessCount();
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
                Thread.SpinWait(10);
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
                DataGridViewTemplateInitialLoad.Hw(this.dataGridViewOne);
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

        /// <summary>
        /// 重置窗口大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReBlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 1500;
            this.Height = 836;
        }

        /// <summary>
        /// 录像目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void replaysFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string paht = @"" + InitialUtils.GetHome() + "replays";
            System.Diagnostics.Process.Start("explorer.exe", paht);
        }

        /// <summary>
        /// mods文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 重置缓存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string paht = @"" + System.Environment.CurrentDirectory + "\\logs";
            System.Diagnostics.Process.Start("explorer.exe", paht);
        }

        /// <summary>
        /// 右键功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewOne_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 1)
                {
                    string v = null;
                    if (e.ColumnIndex <= 4)
                    {
                        //获取友方数据
                        v = this.dataGridViewOne.Rows[e.RowIndex].Cells[0].Value.ToString();

                    }
                    else if (e.ColumnIndex >= 6)
                    {
                        //获取敌方
                        v = this.dataGridViewOne.Rows[e.RowIndex].Cells[10].Value.ToString();
                    }
                    log.Info("右键内容=" + v);
                    if (!string.IsNullOrEmpty(v))
                    {
                        this.contextMenuStripData.Show(MousePosition.X, MousePosition.Y);
                        this.contextMenuStripData.Click += new System.EventHandler((sender2, e2) =>
                        {
                            GameAccountInfoData game = null;
                            foreach (var item in GAME_INFO_LIST)
                            {
                                if (item.AccountName.Equals(v))
                                {
                                    game = item;
                                }
                            }
                            if (game != null)
                            {
                                try
                                {
                                    StringBuilder builder = new StringBuilder();
                                    if (game.Hide)
                                    {
                                        builder.Append(game.AccountName).Append("隐藏了战绩...");
                                    }
                                    else
                                    {
                                        GameAccountShipInfoData ship = game.GameAccountShipInfo;
                                        builder.Append(game.AccountName).Append("").Append(Environment.NewLine)
                                        .Append(game.Battles).Append("场，胜率").Append(game.GameWins().ToString("f2")).Append("%").Append(Environment.NewLine)
                                        .Append(ship.ShipName).Append(" 场均").Append(ship.GameDamage()).Append("，").Append(ship.Battles).Append("场，胜率")
                                        .Append(ship.GameWins().ToString("f2")).Append("%").Append(Environment.NewLine).Append(" 评分(PR)=").Append(ship.Pr);
                                    }
                                    Clipboard.SetText(builder.ToString());
                                }
                                catch (Exception ex)
                                {
                                    log.Error("粘贴内容出现异常" + ex);
                                }
                            }
                        });
                    }
                }
            }
        }

        /// <summary>
        /// 提供一个手动选择游戏路径的选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewGamePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PathHome home = new PathHome();
            home.ShowDialog();
        }

        /// <summary>
        /// 重置路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.GameHomePath = "N/A";
            Settings.Default.Save();
            LoadGameHome();
        }


        /// <summary>
        /// 检测更新
        /// </summary>
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
                        MessageBox.Show("版本过低！！！\r\n请去网站更新最新版本\r\nhttp://v.wows.shinoaki.com");
                        //System.Diagnostics.Process.GetProcessById(System.Diagnostics.Process.GetCurrentProcess().Id).Kill();
                    }
                    else
                    {
                        MessageBox.Show("发现新版本，请去网站更新最新版本\r\nhttp://v.wows.shinoaki.com");
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
        /// 关于界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuanYuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Author author = new Author();
            author.ShowDialog();
        }

        /// <summary>
        /// 选中事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewOne_SelectionChanged(object sender, EventArgs e)
        {
            this.dataGridViewOne.ClearSelection();
        }
    }
}
