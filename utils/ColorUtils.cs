using System;
using System.Drawing;

namespace WowsTools.utils
{
    class ColorUtils
    {
        public static Color PrColor(int pr)
        {
            Color color = Color.FromArgb(Convert.ToInt32("ffff6e66", 16));
            if (pr <= 750)
            {
                return color;
            }
            else if (pr <= 1100)
            {
                color = Color.FromArgb(Convert.ToInt32("ffffae66", 16));
            }
            else if (pr <= 1350)
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

        public static Color PrColor(int pr,int i)
        {
            Color color = Color.FromArgb(Convert.ToInt32("ffff6e66", 16));
            if (pr <= 0)
            {
                return color;
            }
            else if (pr <= 1)
            {
                color = Color.FromArgb(Convert.ToInt32("ffffae66", 16));
            }
            else if (pr <= 2)
            {
                color = Color.FromArgb(Convert.ToInt32("ffffc51a", 16));
            }
            else if (pr <= 3)
            {
                color = Color.FromArgb(Convert.ToInt32("ff58e600", 16));
            }
            else if (pr <= 4)
            {
                color = Color.FromArgb(Convert.ToInt32("ff4ecc00", 16));
            }
            else if (pr <= 5)
            {
                color = Color.FromArgb(Convert.ToInt32("ff03e3cb", 16));
            }
            else if (pr <= 6)
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
            Color color = Color.FromArgb(254, 14, 0);
            if (wins < 45.0)
            {
                return color;
            }
            else if (wins < 50.0)
            {
                color = Color.FromArgb(254, 121, 3);
            }
            else if (wins < 55.0)
            {
                color = Color.FromArgb(68, 179, 0);
            }
            else if (wins < 60.0)
            {
                color = Color.FromArgb(49, 128, 0);
            }
            else if (wins < 65.0)
            {
                color = Color.FromArgb(2, 201, 179);
            }
            else if (wins < 70)
            {
                color = Color.FromArgb(208, 66, 243);
            }
            else
            {
                color = Color.FromArgb(160, 13, 197);
            }
            return color;
        }
    }
}
