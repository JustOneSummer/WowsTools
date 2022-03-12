using System.Drawing;

namespace WowsTools.utils
{
    class ColorUtils
    {
        public static Color PrColor(int pr)
        {
            Color color = Color.FromArgb(254, 14, 0);
            if (pr <= 750)
            {
                return color;
            }
            else if (pr <= 1100)
            {
                color = Color.FromArgb(254, 121, 3);
            }
            else if (pr <= 1350)
            {
                color = Color.FromArgb(255, 199, 31);
            }
            else if (pr <= 1550)
            {
                color = Color.FromArgb(68, 179, 0);
            }
            else if (pr <= 1750)
            {
                color = Color.FromArgb(49, 128, 0);
            }
            else if (pr <= 2100)
            {
                color = Color.FromArgb(2, 201, 179);
            }
            else if (pr <= 2450)
            {
                color = Color.FromArgb(208, 66, 243);
            }
            else
            {
                color = Color.FromArgb(160, 13, 197);
            }
            return color;
        }

        public static Color WinsColor(string winsData)
        {
            if ("N/A".Equals(winsData))
            {
                return Color.FromArgb(254, 14, 0);
            }
            double wins = double.Parse(winsData.Substring(0, winsData.Length - 1));
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
