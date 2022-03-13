
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WowsMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.UpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GuanYuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BattleInterfaceWidthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ServerLable = new System.Windows.Forms.Label();
            this.dataGridViewOne = new System.Windows.Forms.DataGridView();
            this.labelWinsA = new System.Windows.Forms.Label();
            this.labelWinsB = new System.Windows.Forms.Label();
            this.dataGridViewTwo = new System.Windows.Forms.DataGridView();
            this.labelMyTeam = new System.Windows.Forms.Label();
            this.labelDIJun = new System.Windows.Forms.Label();
            this.timerGameCheck = new System.Windows.Forms.Timer(this.components);
            this.labelStatusInfo = new System.Windows.Forms.Label();
            this.labelGamePath = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTwo)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SetUpToolStripMenuItem,
            this.UpdateToolStripMenuItem,
            this.GuanYuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1484, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // UpdateToolStripMenuItem
            // 
            this.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem";
            this.UpdateToolStripMenuItem.Size = new System.Drawing.Size(47, 23);
            this.UpdateToolStripMenuItem.Text = "刷新";
            this.UpdateToolStripMenuItem.Click += new System.EventHandler(this.UpdateToolStripMenuItem_Click);
            // 
            // GuanYuToolStripMenuItem
            // 
            this.GuanYuToolStripMenuItem.Name = "GuanYuToolStripMenuItem";
            this.GuanYuToolStripMenuItem.Size = new System.Drawing.Size(47, 23);
            this.GuanYuToolStripMenuItem.Text = "关于";
            this.GuanYuToolStripMenuItem.Click += new System.EventHandler(this.GuanYuToolStripMenuItem_Click);
            // 
            // SetUpToolStripMenuItem
            // 
            this.SetUpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BattleInterfaceWidthToolStripMenuItem});
            this.SetUpToolStripMenuItem.Name = "SetUpToolStripMenuItem";
            this.SetUpToolStripMenuItem.Size = new System.Drawing.Size(47, 23);
            this.SetUpToolStripMenuItem.Text = "设置";
            // 
            // BattleInterfaceWidthToolStripMenuItem
            // 
            this.BattleInterfaceWidthToolStripMenuItem.Name = "BattleInterfaceWidthToolStripMenuItem";
            this.BattleInterfaceWidthToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.BattleInterfaceWidthToolStripMenuItem.Text = "对战界面宽度";
            // 
            // ServerLable
            // 
            this.ServerLable.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ServerLable.AutoSize = true;
            this.ServerLable.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ServerLable.ForeColor = System.Drawing.Color.Blue;
            this.ServerLable.Location = new System.Drawing.Point(718, 37);
            this.ServerLable.Name = "ServerLable";
            this.ServerLable.Size = new System.Drawing.Size(51, 26);
            this.ServerLable.TabIndex = 1;
            this.ServerLable.Text = "N/A";
            // 
            // dataGridViewOne
            // 
            this.dataGridViewOne.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewOne.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewOne.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOne.Location = new System.Drawing.Point(12, 72);
            this.dataGridViewOne.Name = "dataGridViewOne";
            this.dataGridViewOne.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewOne.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridViewOne.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewOne.RowTemplate.Height = 23;
            this.dataGridViewOne.Size = new System.Drawing.Size(715, 378);
            this.dataGridViewOne.TabIndex = 2;
            this.dataGridViewOne.SelectionChanged += new System.EventHandler(this.dataGridViewOne_SelectionChanged);
            // 
            // labelWinsA
            // 
            this.labelWinsA.AutoSize = true;
            this.labelWinsA.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelWinsA.ForeColor = System.Drawing.Color.Black;
            this.labelWinsA.Location = new System.Drawing.Point(402, 37);
            this.labelWinsA.Name = "labelWinsA";
            this.labelWinsA.Size = new System.Drawing.Size(149, 26);
            this.labelWinsA.TabIndex = 4;
            this.labelWinsA.Text = "平均胜率：50%";
            // 
            // labelWinsB
            // 
            this.labelWinsB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWinsB.AutoSize = true;
            this.labelWinsB.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelWinsB.Location = new System.Drawing.Point(859, 37);
            this.labelWinsB.Name = "labelWinsB";
            this.labelWinsB.Size = new System.Drawing.Size(149, 26);
            this.labelWinsB.TabIndex = 5;
            this.labelWinsB.Text = "平均胜率：50%";
            // 
            // dataGridViewTwo
            // 
            this.dataGridViewTwo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTwo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTwo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTwo.Location = new System.Drawing.Point(757, 72);
            this.dataGridViewTwo.Name = "dataGridViewTwo";
            this.dataGridViewTwo.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTwo.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridViewTwo.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTwo.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridViewTwo.RowTemplate.Height = 23;
            this.dataGridViewTwo.Size = new System.Drawing.Size(715, 378);
            this.dataGridViewTwo.TabIndex = 6;
            this.dataGridViewTwo.SelectionChanged += new System.EventHandler(this.dataGridViewTwo_SelectionChanged);
            // 
            // labelMyTeam
            // 
            this.labelMyTeam.AutoSize = true;
            this.labelMyTeam.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelMyTeam.ForeColor = System.Drawing.Color.Green;
            this.labelMyTeam.Location = new System.Drawing.Point(624, 37);
            this.labelMyTeam.Name = "labelMyTeam";
            this.labelMyTeam.Size = new System.Drawing.Size(88, 26);
            this.labelMyTeam.TabIndex = 7;
            this.labelMyTeam.Text = "我的团队";
            // 
            // labelDIJun
            // 
            this.labelDIJun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDIJun.AutoSize = true;
            this.labelDIJun.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDIJun.ForeColor = System.Drawing.Color.Red;
            this.labelDIJun.Location = new System.Drawing.Point(772, 37);
            this.labelDIJun.Name = "labelDIJun";
            this.labelDIJun.Size = new System.Drawing.Size(50, 26);
            this.labelDIJun.TabIndex = 8;
            this.labelDIJun.Text = "敌军";
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
            this.labelStatusInfo.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStatusInfo.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelStatusInfo.Location = new System.Drawing.Point(1300, 37);
            this.labelStatusInfo.Name = "labelStatusInfo";
            this.labelStatusInfo.Size = new System.Drawing.Size(50, 26);
            this.labelStatusInfo.TabIndex = 10;
            this.labelStatusInfo.Text = "等待";
            // 
            // labelGamePath
            // 
            this.labelGamePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelGamePath.AutoSize = true;
            this.labelGamePath.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelGamePath.ForeColor = System.Drawing.Color.Red;
            this.labelGamePath.Location = new System.Drawing.Point(1116, 37);
            this.labelGamePath.Name = "labelGamePath";
            this.labelGamePath.Size = new System.Drawing.Size(145, 26);
            this.labelGamePath.TabIndex = 11;
            this.labelGamePath.Text = "未识别游戏路径";
            // 
            // WowsMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 462);
            this.Controls.Add(this.labelGamePath);
            this.Controls.Add(this.labelStatusInfo);
            this.Controls.Add(this.labelDIJun);
            this.Controls.Add(this.labelMyTeam);
            this.Controls.Add(this.dataGridViewTwo);
            this.Controls.Add(this.labelWinsB);
            this.Controls.Add(this.labelWinsA);
            this.Controls.Add(this.dataGridViewOne);
            this.Controls.Add(this.ServerLable);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "WowsMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "战舰世界工具箱";
            this.Load += new System.EventHandler(this.WowsMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTwo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem GuanYuToolStripMenuItem;
        private System.Windows.Forms.Label ServerLable;
        private System.Windows.Forms.DataGridView dataGridViewOne;
        private System.Windows.Forms.Label labelWinsA;
        private System.Windows.Forms.Label labelWinsB;
        private System.Windows.Forms.DataGridView dataGridViewTwo;
        private System.Windows.Forms.Label labelMyTeam;
        private System.Windows.Forms.Label labelDIJun;
        private System.Windows.Forms.Timer timerGameCheck;
        private System.Windows.Forms.ToolStripMenuItem UpdateToolStripMenuItem;
        private System.Windows.Forms.Label labelStatusInfo;
        private System.Windows.Forms.Label labelGamePath;
        private System.Windows.Forms.ToolStripMenuItem SetUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BattleInterfaceWidthToolStripMenuItem;
    }
}

