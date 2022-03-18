using System;
using System.Drawing;
using WowsTools.Properties;

namespace WowsTools.utils
{
    class ColorUtils
    {
        /// <summary>
        /// 评分区分
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        public static Color PrColor(int pr)
        {
            if (pr <= 0)
            {
                return Color.FromArgb(Convert.ToInt32(Settings.Default.PrColor0, 16));
            }
            Color color = Color.FromArgb(Convert.ToInt32(Settings.Default.PrColor1, 16));
            if (pr <= 750)
            {
                return color;
            }
            else if (pr <= 1100)
            {
                color = Color.FromArgb(Convert.ToInt32(Settings.Default.PrColor2, 16));
            }
            else
            if (pr <= 1350)
            {
                color = Color.FromArgb(Convert.ToInt32(Settings.Default.PrColor3, 16));
            }
            else if (pr <= 1550)
            {
                color = Color.FromArgb(Convert.ToInt32(Settings.Default.PrColor4, 16));
            }
            else if (pr <= 1750)
            {
                color = Color.FromArgb(Convert.ToInt32(Settings.Default.PrColor5, 16));
            }
            else if (pr <= 2100)
            {
                color = Color.FromArgb(Convert.ToInt32(Settings.Default.PrColor6, 16));
            }
            else if (pr <= 2450)
            {
                color = Color.FromArgb(Convert.ToInt32(Settings.Default.PrColor7, 16));
            }
            else
            {
                color = Color.FromArgb(Convert.ToInt32(Settings.Default.PrColor8, 16));
            }
            return color;
        }

        /// <summary>
        /// 颜色区分
        /// </summary>
        /// <param name="wins"></param>
        /// <returns></returns>
        public static Color WinsColor(double wins)
        {
            if (wins <= 0.0)
            {
                return Color.FromArgb(Convert.ToInt32(Settings.Default.PrColor0, 16));
            }
            Color color = Color.FromArgb(Convert.ToInt32(Settings.Default.WinsColor1, 16));
            if (wins <= Settings.Default.WinsColorValue1)
            {
                return color;
            }
            else if (wins <= Settings.Default.WinsColorValue2)
            {
                color = Color.FromArgb(Convert.ToInt32(Settings.Default.WinsColor2, 16));
            }
            else
            {
                color = Color.FromArgb(Convert.ToInt32(Settings.Default.WinsColor3, 16));

            }
            return color;
        }
    }
}
