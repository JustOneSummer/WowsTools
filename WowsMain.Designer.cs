
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WowsMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SheZhiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GuanYuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ServerLable = new System.Windows.Forms.Label();
            this.dataGridViewOne = new System.Windows.Forms.DataGridView();
            this.VsLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewTwo = new System.Windows.Forms.DataGridView();
            this.labelMyTeam = new System.Windows.Forms.Label();
            this.labelDIJun = new System.Windows.Forms.Label();
            this.timerGameCheck = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTwo)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SheZhiToolStripMenuItem,
            this.GuanYuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1484, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // SheZhiToolStripMenuItem
            // 
            this.SheZhiToolStripMenuItem.Name = "SheZhiToolStripMenuItem";
            this.SheZhiToolStripMenuItem.Size = new System.Drawing.Size(47, 23);
            this.SheZhiToolStripMenuItem.Text = "设置";
            // 
            // GuanYuToolStripMenuItem
            // 
            this.GuanYuToolStripMenuItem.Name = "GuanYuToolStripMenuItem";
            this.GuanYuToolStripMenuItem.Size = new System.Drawing.Size(47, 23);
            this.GuanYuToolStripMenuItem.Text = "关于";
            this.GuanYuToolStripMenuItem.Click += new System.EventHandler(this.GuanYuToolStripMenuItem_Click);
            // 
            // ServerLable
            // 
            this.ServerLable.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ServerLable.AutoSize = true;
            this.ServerLable.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ServerLable.ForeColor = System.Drawing.Color.Blue;
            this.ServerLable.Location = new System.Drawing.Point(718, 37);
            this.ServerLable.Name = "ServerLable";
            this.ServerLable.Size = new System.Drawing.Size(50, 26);
            this.ServerLable.TabIndex = 1;
            this.ServerLable.Text = "亚服";
            // 
            // dataGridViewOne
            // 
            this.dataGridViewOne.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewOne.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOne.Location = new System.Drawing.Point(12, 72);
            this.dataGridViewOne.Name = "dataGridViewOne";
            this.dataGridViewOne.RowTemplate.Height = 23;
            this.dataGridViewOne.Size = new System.Drawing.Size(700, 331);
            this.dataGridViewOne.TabIndex = 2;
            // 
            // VsLabel
            // 
            this.VsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.VsLabel.AutoSize = true;
            this.VsLabel.Font = new System.Drawing.Font("微软雅黑", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.VsLabel.ForeColor = System.Drawing.Color.Red;
            this.VsLabel.Location = new System.Drawing.Point(722, 165);
            this.VsLabel.Name = "VsLabel";
            this.VsLabel.Size = new System.Drawing.Size(37, 26);
            this.VsLabel.TabIndex = 3;
            this.VsLabel.Text = "VS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(402, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "平均胜率：55.47%";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(859, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "平均胜率：56.67%";
            // 
            // dataGridViewTwo
            // 
            this.dataGridViewTwo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTwo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTwo.Location = new System.Drawing.Point(772, 72);
            this.dataGridViewTwo.Name = "dataGridViewTwo";
            this.dataGridViewTwo.RowTemplate.Height = 23;
            this.dataGridViewTwo.Size = new System.Drawing.Size(700, 331);
            this.dataGridViewTwo.TabIndex = 6;
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
            // WowsMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 415);
            this.Controls.Add(this.labelDIJun);
            this.Controls.Add(this.labelMyTeam);
            this.Controls.Add(this.dataGridViewTwo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VsLabel);
            this.Controls.Add(this.dataGridViewOne);
            this.Controls.Add(this.ServerLable);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTwo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem SheZhiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GuanYuToolStripMenuItem;
        private System.Windows.Forms.Label ServerLable;
        private System.Windows.Forms.DataGridView dataGridViewOne;
        private System.Windows.Forms.Label VsLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewTwo;
        private System.Windows.Forms.Label labelMyTeam;
        private System.Windows.Forms.Label labelDIJun;
        private System.Windows.Forms.Timer timerGameCheck;
    }
}

