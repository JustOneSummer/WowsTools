
namespace WowsTools
{
    partial class Author
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Author));
            this.labelHome = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabelQQ = new System.Windows.Forms.LinkLabel();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // labelHome
            // 
            this.labelHome.AutoSize = true;
            this.labelHome.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelHome.Location = new System.Drawing.Point(117, 18);
            this.labelHome.Name = "labelHome";
            this.labelHome.Size = new System.Drawing.Size(272, 31);
            this.labelHome.TabIndex = 0;
            this.labelHome.Text = "yuyuko战舰世界工具箱";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(173, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "作者：西行寺雨季";
            // 
            // linkLabelQQ
            // 
            this.linkLabelQQ.AutoSize = true;
            this.linkLabelQQ.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabelQQ.Location = new System.Drawing.Point(182, 110);
            this.linkLabelQQ.Name = "linkLabelQQ";
            this.linkLabelQQ.Size = new System.Drawing.Size(117, 22);
            this.linkLabelQQ.TabIndex = 3;
            this.linkLabelQQ.TabStop = true;
            this.linkLabelQQ.Text = "yuyuko交流群";
            this.linkLabelQQ.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelQQ_LinkClicked);
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Image = global::WowsTools.Properties.Resources._1647070636189;
            this.pictureBoxImage.Location = new System.Drawing.Point(150, 145);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(188, 171);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImage.TabIndex = 4;
            this.pictureBoxImage.TabStop = false;
            // 
            // Author
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 328);
            this.Controls.Add(this.pictureBoxImage);
            this.Controls.Add(this.linkLabelQQ);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelHome);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Author";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Author";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabelQQ;
        private System.Windows.Forms.PictureBox pictureBoxImage;
    }
}