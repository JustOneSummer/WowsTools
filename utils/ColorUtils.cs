using System;
using System.Drawing;

namespace WowsTools.utils
{
    class ColorUtils
    {
        public static Color PrColor(int pr)
        {
            if (pr <= 0)
            {
                return Color.FromArgb(Convert.ToInt32("ff63B8FF", 16));
            }
            Color color = Color.FromArgb(Convert.ToInt32("ffff6e66", 16));
            if (pr <= 750)
            {
                return color;
            }
            else if (pr <= 1100)
            {
                color = Color.FromArgb(Convert.ToInt32("ffffae66", 16));
            }
            else
            if (pr <= 1350)
            {
                color = Color.FromArgb(Convert.ToInt32("ffffc51a", 16));
            }
            else if (pr <= 1550)
            {
                color = Color.FromArgb(Convert.ToInt32("ff58e600", 16));
            }
            else if (pr <= 1750)
            {
                color = Color.FromArgb(Convert.ToInt32("ff4ecc00", 16));
            }
            else if (pr <= 2100)
            {
                color = Color.FromArgb(Convert.ToInt32("ff03e3cb", 16));
            }
            else if (pr <= 2450)
            {
                color = Color.FromArgb(Convert.ToInt32("ffda70f5", 16));
            }
            else
            {
                color = Color.FromArgb(Convert.ToInt32("ffc111ee", 16));
            }
            return color;
        }
        public static Color WinsColor(double wins)
        {
            Color color = Color.FromArgb(Convert.ToInt32("ffffae66", 16));
            if (wins <= 48.0)
            {
                return color;
            }
            else if (wins <= 60)
            {
                color = Color.FromArgb(Convert.ToInt32("ff03e3cb", 16));
            }
            else
            {
                color = Color.FromArgb(Convert.ToInt32("ffc111ee", 16));

            }
            return color;
        }
    }
}
