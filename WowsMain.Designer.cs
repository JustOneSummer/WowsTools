
namespace WowsTools
{
    partial class WowsMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WowsMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SetUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ColoursTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsLoadViewToolStripMenuItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptonsReAnalyzeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaysFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modsFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReBlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GuanYuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewOne = new System.Windows.Forms.DataGridView();
            this.timerGameCheck = new System.Windows.Forms.Timer(this.components);
            this.labelStatusInfo = new System.Windows.Forms.Label();
            this.labelGamePath = new System.Windows.Forms.Label();
            this.ReloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOne)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SetUpToolStripMenuItem,
            this.OptionsToolStripMenuItem,
            this.replaysFileToolStripMenuItem,
            this.modsFileToolStripMenuItem,
            this.ReBlockToolStripMenuItem,
            this.GuanYuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1484, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // SetUpToolStripMenuItem
            // 
            this.SetUpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ColoursTemplateToolStripMenuItem,
            this.PrColorToolStripMenuItem,
            this.ReloadToolStripMenuItem});
            this.SetUpToolStripMenuItem.Name = "SetUpToolStripMenuItem";
            this.SetUpToolStripMenuItem.Size = new System.Drawing.Size(47, 23);
            this.SetUpToolStripMenuItem.Text = "设置";
            // 
            // ColoursTemplateToolStripMenuItem
            // 
            this.ColoursTemplateToolStripMenuItem.Name = "ColoursTemplateToolStripMenuItem";
            this.ColoursTemplateToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.ColoursTemplateToolStripMenuItem.Text = "选择渲染模板";
            this.ColoursTemplateToolStripMenuItem.Click += new System.EventHandler(this.ColoursTemplateToolStripMenuItem_Click);
            // 
            // PrColorToolStripMenuItem
            // 
            this.PrColorToolStripMenuItem.Name = "PrColorToolStripMenuItem";
            this.PrColorToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.PrColorToolStripMenuItem.Text = "评分颜色";
            this.PrColorToolStripMenuItem.Click += new System.EventHandler(this.PrColorToolStripMenuItem_Click);
            // 
            // OptionsToolStripMenuItem
            // 
            this.OptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptionsLoadViewToolStripMenuItemToolStripMenuItem,
            this.OptonsReAnalyzeToolStripMenuItem});
            this.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem";
            this.OptionsToolStripMenuItem.Size = new System.Drawing.Size(47, 23);
            this.OptionsToolStripMenuItem.Text = "选项";
            // 
            // OptionsLoadViewToolStripMenuItemToolStripMenuItem
            // 
            this.OptionsLoadViewToolStripMenuItemToolStripMenuItem.Name = "OptionsLoadViewToolStripMenuItemToolStripMenuItem";
            this.OptionsLoadViewToolStripMenuItemToolStripMenuItem.Size = new System.Drawing.Size(169, 24);
            this.OptionsLoadViewToolStripMenuItemToolStripMenuItem.Text = "重新渲染";
            this.OptionsLoadViewToolStripMenuItemToolStripMenuItem.Click += new System.EventHandler(this.OptionsLoadViewToolStripMenuItemToolStripMenuItem_Click);
            // 
            // OptonsReAnalyzeToolStripMenuItem
            // 
            this.OptonsReAnalyzeToolStripMenuItem.Name = "OptonsReAnalyzeToolStripMenuItem";
            this.OptonsReAnalyzeToolStripMenuItem.Size = new System.Drawing.Size(169, 24);
            this.OptonsReAnalyzeToolStripMenuItem.Text = "重置设置和缓存";
            this.OptonsReAnalyzeToolStripMenuItem.Click += new System.EventHandler(this.OptonsReAnalyzeToolStripMenuItem_Click);
            // 
            // replaysFileToolStripMenuItem
            // 
            this.replaysFileToolStripMenuItem.Name = "replaysFileToolStripMenuItem";
            this.replaysFileToolStripMenuItem.Size = new System.Drawing.Size(90, 23);
            this.replaysFileToolStripMenuItem.Text = "replays目录";
            this.replaysFileToolStripMenuItem.Click += new System.EventHandler(this.replaysFileToolStripMenuItem_Click);
            // 
            // modsFileToolStripMenuItem
            // 
            this.modsFileToolStripMenuItem.Name = "modsFileToolStripMenuItem";
            this.modsFileToolStripMenuItem.Size = new System.Drawing.Size(81, 23);
            this.modsFileToolStripMenuItem.Text = "mods目录";
            this.modsFileToolStripMenuItem.Click += new System.EventHandler(this.modsFileToolStripMenuItem_Click);
            // 
            // ReBlockToolStripMenuItem
            // 
            this.ReBlockToolStripMenuItem.Name = "ReBlockToolStripMenuItem";
            this.ReBlockToolStripMenuItem.Size = new System.Drawing.Size(47, 23);
            this.ReBlockToolStripMenuItem.Text = "恢复";
            this.ReBlockToolStripMenuItem.Click += new System.EventHandler(this.ReBlockToolStripMenuItem_Click);
            // 
            // GuanYuToolStripMenuItem
            // 
            this.GuanYuToolStripMenuItem.Name = "GuanYuToolStripMenuItem";
            this.GuanYuToolStripMenuItem.Size = new System.Drawing.Size(47, 23);
            this.GuanYuToolStripMenuItem.Text = "关于";
            this.GuanYuToolStripMenuItem.Click += new System.EventHandler(this.GuanYuToolStripMenuItem_Click);
            // 
            // dataGridViewOne
            // 
            this.dataGridViewOne.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewOne.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewOne.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewOne.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridViewOne.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewOne.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewOne.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOne.Location = new System.Drawing.Point(12, 30);
            this.dataGridViewOne.Name = "dataGridViewOne";
            this.dataGridViewOne.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewOne.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridViewOne.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewOne.RowTemplate.Height = 23;
            this.dataGridViewOne.Size = new System.Drawing.Size(1460, 756);
            this.dataGridViewOne.TabIndex = 2;
            this.dataGridViewOne.SelectionChanged += new System.EventHandler(this.dataGridViewOne_SelectionChanged);
            // 
            // timerGameCheck
            // 
            this.timerGameCheck.Enabled = true;
            this.timerGameCheck.Interval = 3000;
            this.timerGameCheck.Tick += new System.EventHandler(this.timerGameCheck_Tick);
            // 
            // labelStatusInfo
            // 
            this.labelStatusInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStatusInfo.AutoSize = true;
            this.labelStatusInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStatusInfo.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelStatusInfo.Location = new System.Drawing.Point(1299, 5);
            this.labelStatusInfo.Name = "labelStatusInfo";
            this.labelStatusInfo.Size = new System.Drawing.Size(42, 22);
            this.labelStatusInfo.TabIndex = 10;
            this.labelStatusInfo.Text = "等待";
            // 
            // labelGamePath
            // 
            this.labelGamePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelGamePath.AutoSize = true;
            this.labelGamePath.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelGamePath.ForeColor = System.Drawing.Color.Red;
            this.labelGamePath.Location = new System.Drawing.Point(1162, 5);
            this.labelGamePath.Name = "labelGamePath";
            this.labelGamePath.Size = new System.Drawing.Size(122, 22);
            this.labelGamePath.TabIndex = 11;
            this.labelGamePath.Text = "未识别游戏路径";
            // 
            // ReloadToolStripMenuItem
            // 
            this.ReloadToolStripMenuItem.Name = "ReloadToolStripMenuItem";
            this.ReloadToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.ReloadToolStripMenuItem.Text = "重置设置";
            this.ReloadToolStripMenuItem.Click += new System.EventHandler(this.ReloadToolStripMenuItem_Click);
            // 
            // WowsMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 797);
            this.Controls.Add(this.labelGamePath);
            this.Controls.Add(this.labelStatusInfo);
            this.Controls.Add(this.dataGridViewOne);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "WowsMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "战舰世界工具箱";
            this.Load += new System.EventHandler(this.WowsMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOne)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem GuanYuToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewOne;
        private System.Windows.Forms.Timer timerGameCheck;
        private System.Windows.Forms.Label labelStatusInfo;
        private System.Windows.Forms.Label labelGamePath;
        private System.Windows.Forms.ToolStripMenuItem SetUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ColoursTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptionsLoadViewToolStripMenuItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptonsReAnalyzeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReBlockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaysFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modsFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PrColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReloadToolStripMenuItem;
    }
}

