using System;
using System.Drawing;
using System.Windows.Forms;
using WowsTools.Properties;

namespace WowsTools
{
    /// <summary>
    /// 委托
    /// </summary>
    public delegate void SaveReloadPrBackColorSettingsEvent();
    public partial class PrBackColorSettings : Form
    {
        /// <summary>
        /// 事件
        /// </summary>
        public event SaveReloadPrBackColorSettingsEvent SaveReloadEvent;
        public PrBackColorSettings()
        {
            InitializeComponent();
        }

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 存储所有值，并且退出生效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            SaveDataInfo();
            this.Close();
            SaveReloadEvent();
        }

        private void PrBackColorSettings_Load(object sender, EventArgs e)
        {
            this.textBoxPrColor1.Text = Settings.Default.PrColor1;
            this.textBoxPrColor2.Text = Settings.Default.PrColor2;
            this.textBoxPrColor3.Text = Settings.Default.PrColor3;
            this.textBoxPrColor4.Text = Settings.Default.PrColor4;
            this.textBoxPrColor5.Text = Settings.Default.PrColor5;
            this.textBoxPrColor6.Text = Settings.Default.PrColor6;
            this.textBoxPrColor7.Text = Settings.Default.PrColor7;
            this.textBoxPrColor8.Text = Settings.Default.PrColor8;
            this.textBoxColorZero.Text = Settings.Default.PrColor0;
            Colors(this.textBoxTestPr0, Settings.Default.PrColor0);
            Colors(this.textBoxTestPr1, Settings.Default.PrColor1);
            Colors(this.textBoxTestPr2, Settings.Default.PrColor2);
            Colors(this.textBoxTestPr3, Settings.Default.PrColor3);
            Colors(this.textBoxTestPr4, Settings.Default.PrColor4);
            Colors(this.textBoxTestPr5, Settings.Default.PrColor5);
            Colors(this.textBoxTestPr6, Settings.Default.PrColor6);
            Colors(this.textBoxTestPr7, Settings.Default.PrColor7);
            Colors(this.textBoxTestPr8, Settings.Default.PrColor8);

            this.textBoxPrNa.Text = Settings.Default.PrColorNA;
            this.textBoxMb1.Text = Settings.Default.DataGridViewTemplateForeColor0;
            this.textBoxMb2.Text = Settings.Default.DataGridViewTemplateForeColor1;
            Colors(this.textBoxTestNa, Settings.Default.PrColorNA);
            Colors(this.textBoxTestMb1, Settings.Default.DataGridViewTemplateForeColor0);
            Colors(this.textBoxTestMb2, Settings.Default.DataGridViewTemplateForeColor1);
            //胜率
            this.textBoxWinsValue1.Text = Settings.Default.WinsColorValue1.ToString();
            this.textBoxWinsValue2.Text = Settings.Default.WinsColorValue2.ToString();
            this.textBoxWinsValue3.Text = Settings.Default.WinsColorValue3.ToString();
            this.textBoxWinsValue4.Text = Settings.Default.WinsColorValue4.ToString();
            this.textBoxWinsColor1.Text = Settings.Default.WinsColor1;
            this.textBoxWinsColor2.Text = Settings.Default.WinsColor2;
            this.textBoxWinsColor3.Text = Settings.Default.WinsColor3;
            this.textBoxWinsColor4.Text = Settings.Default.WinsColor4;
            this.textBoxWinsColor5.Text = Settings.Default.WinsColor5;
            Colors(this.textBoxTestWins1, Settings.Default.WinsColor1);
            Colors(this.textBoxTestWins2, Settings.Default.WinsColor2);
            Colors(this.textBoxTestWins3, Settings.Default.WinsColor3);
            Colors(this.textBoxTestWins4, Settings.Default.WinsColor4);
            Colors(this.textBoxTestWins5, Settings.Default.WinsColor5);

            Color color = Color.Green;
            if (Settings.Default.GamePrBackColorSelect == 0)
            {
                this.button1.BackColor = color;
            }
            else
            {
                this.button2.BackColor = color;
            }
            //值
            this.textBoxPr1.Text = Settings.Default.PrValue1.ToString();
            this.textBoxPr2.Text = Settings.Default.PrValue2.ToString();
            this.textBoxPr3.Text = Settings.Default.PrValue3.ToString();
            this.textBoxPr4.Text = Settings.Default.PrValue4.ToString();
            this.textBoxPr5.Text = Settings.Default.PrValue5.ToString();
            this.textBoxPr6.Text = Settings.Default.PrValue6.ToString();
            this.textBoxPr7.Text = Settings.Default.PrValue7.ToString();
        }

        /// <summary>
        /// pr
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Settings.Default.GamePrBackColorSelect = 0;
            Settings.Default.Save();
            this.button1.BackColor = Color.Green;
            this.button2.BackColor = Color.White;
        }

        /// <summary>
        /// wins
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Settings.Default.GamePrBackColorSelect = 1;
            Settings.Default.Save();
            this.button1.BackColor = Color.White;
            this.button2.BackColor = Color.Green;
        }

        private static void Colors(TextBox textBox, string color)
        {
            try
            {
                textBox.BackColor = Color.FromArgb(Convert.ToInt32(color, 16));
            }
            catch (Exception e)
            {
                log.Error("渲染颜色发生错误 " + e);
            }
        }

        private void SaveDataInfo()
        {
            Settings.Default.PrColor0 = this.textBoxColorZero.Text.Trim();
            Settings.Default.PrColor1 = this.textBoxPrColor1.Text.Trim();
            Settings.Default.PrColor2 = this.textBoxPrColor2.Text.Trim();
            Settings.Default.PrColor3 = this.textBoxPrColor3.Text.Trim();
            Settings.Default.PrColor4 = this.textBoxPrColor4.Text.Trim();
            Settings.Default.PrColor5 = this.textBoxPrColor5.Text.Trim();
            Settings.Default.PrColor6 = this.textBoxPrColor6.Text.Trim();
            Settings.Default.PrColor7 = this.textBoxPrColor7.Text.Trim();
            Settings.Default.PrColor8 = this.textBoxPrColor8.Text.Trim();

            Settings.Default.PrColorNA = this.textBoxPrNa.Text.Trim();
            Settings.Default.DataGridViewTemplateForeColor0 = this.textBoxMb1.Text.Trim();
            Settings.Default.DataGridViewTemplateForeColor1 = this.textBoxMb2.Text.Trim();
            //胜率
            Settings.Default.WinsColorValue1 = double.Parse(this.textBoxWinsValue1.Text.Trim());
            Settings.Default.WinsColorValue2 = double.Parse(this.textBoxWinsValue2.Text.Trim());
            Settings.Default.WinsColorValue3 = double.Parse(this.textBoxWinsValue3.Text.Trim());
            Settings.Default.WinsColorValue4 = double.Parse(this.textBoxWinsValue4.Text.Trim());
            Settings.Default.WinsColor1 = this.textBoxWinsColor1.Text.Trim();
            Settings.Default.WinsColor2 = this.textBoxWinsColor2.Text.Trim();
            Settings.Default.WinsColor3 = this.textBoxWinsColor3.Text.Trim();
            Settings.Default.WinsColor4 = this.textBoxWinsColor4.Text.Trim();
            Settings.Default.WinsColor5 = this.textBoxWinsColor5.Text.Trim();

            Settings.Default.Save();
        }

        /// <summary>
        /// 加载效果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            SaveDataInfo();
            PrBackColorSettings_Load(null, null);
        }

        private void SelectColor(TextBox textBox)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //获取所选择的颜色
                Color color = dlg.Color;
                //改变panel的背景色
                int v = color.ToArgb();
                textBox.Text = Convert.ToString(v, 16);
            }
        }

        private void textBoxTestPr1_Click(object sender, EventArgs e)
        {
            SelectColor(this.textBoxPrColor1);
        }

        private void textBoxTestPr2_Click(object sender, EventArgs e)
        {
            SelectColor(this.textBoxPrColor2);
        }

        private void textBoxTestPr3_Click(object sender, EventArgs e)
        {
            SelectColor(this.textBoxPrColor3);
        }

        private void textBoxTestPr4_Click(object sender, EventArgs e)
        {
            SelectColor(this.textBoxPrColor4);
        }

        private void textBoxTestPr5_Click(object sender, EventArgs e)
        {
            SelectColor(this.textBoxPrColor5);
        }

        private void textBoxTestPr6_Click(object sender, EventArgs e)
        {
            SelectColor(this.textBoxPrColor6);
        }

        private void textBoxTestPr7_Click(object sender, EventArgs e)
        {
            SelectColor(this.textBoxPrColor7);
        }

        private void textBoxTestPr8_Click(object sender, EventArgs e)
        {
            SelectColor(this.textBoxPrColor8);
        }

        private void textBoxTestNa_Click(object sender, EventArgs e)
        {
            SelectColor(this.textBoxPrNa);
        }

        private void textBoxTestMb1_Click(object sender, EventArgs e)
        {
            SelectColor(this.textBoxMb1);
        }

        private void textBoxTestMb2_Click(object sender, EventArgs e)
        {
            SelectColor(this.textBoxMb2);
        }

        private void textBoxTestWins1_Click(object sender, EventArgs e)
        {
            SelectColor(this.textBoxWinsColor1);
        }

        private void textBoxTestWins2_Click(object sender, EventArgs e)
        {
            SelectColor(this.textBoxWinsColor2);
        }

        private void textBoxTestWins3_Click(object sender, EventArgs e)
        {
            SelectColor(this.textBoxWinsColor3);
        }

        private void textBoxTestWins4_Click(object sender, EventArgs e)
        {
            SelectColor(this.textBoxWinsColor4);
        }

        private void textBoxTestWins5_Click(object sender, EventArgs e)
        {
            SelectColor(this.textBoxWinsColor5);
        }

        private void textBoxTestPr0_Click(object sender, EventArgs e)
        {
            SelectColor(this.textBoxColorZero);
        }
    }
}
