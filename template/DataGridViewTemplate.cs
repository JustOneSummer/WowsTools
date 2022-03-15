using System.Drawing;
using System.Windows.Forms;
using WowsTools.model;
using WowsTools.Properties;
using WowsTools.utils;

namespace WowsTools.template
{
    internal class DataGridViewTemplate
    {
        public static DataGridViewRow Template(int i, DataGridView view, GameInfoData gameInfoData)
        {
            int dataGridViewTemplate = Settings.Default.DataGridViewTemplate;
            switch (dataGridViewTemplate)
            {
                case 1:
                    return Two(i, view, gameInfoData);
                default:
                    return One(i, view, gameInfoData);
            }
        }

        /// <summary>
        /// PR背景为PR颜色模板
        /// </summary>
        /// <param name="i"></param>
        /// <param name="view"></param>
        /// <param name="gameInfoData"></param>
        /// <returns></returns>
        public static DataGridViewRow One(int i,DataGridView view,GameInfoData gameInfoData)
        {
            string na = "N/A";
            DataGridViewRow row = new DataGridViewRow();
            GameAccountInfoData data;
            if (i < gameInfoData.TeamOneList.Count)
            {
                data = gameInfoData.TeamOneList[i];
                GameAccountShipInfoData shipData = data.GameAccountShipInfo;
                row.CreateCells(view);
                Color prColor = ColorUtils.PrColor(shipData.Pr);
                row.Cells[0].Value = data.AccountName;
                row.Cells[1].Value = data.Battles;

                row.Cells[2].Value = data.Hide ? na : data.GameWins().ToString("f2") + "%";
                row.Cells[2].Style.ForeColor = ColorUtils.WinsColor(data.GameWins());

                row.Cells[3].Value = ShipUtils.LevelInfo(shipData.ShipLevel);
                row.Cells[4].Value = shipData.ShipName;
                row.Cells[5].Value = data.Hide ? na : shipData.Battles.ToString();
                row.Cells[6].Value = data.Hide ? na : shipData.GameDamage().ToString();

                row.Cells[7].Value = data.Hide ? na : shipData.GameWins().ToString("f2") + "%"; ;
                row.Cells[7].Style.ForeColor = ColorUtils.WinsColor(shipData.GameWins());

                row.Cells[8].Value = data.Hide ? na : shipData.Pr.ToString();
                row.Cells[8].Style.BackColor = ColorUtils.PrColor(shipData.Pr);
            }
            row.Cells[9].Value = "";
            if (i < gameInfoData.TeamTwoList.Count)
            {
                data = gameInfoData.TeamTwoList[i];
                GameAccountShipInfoData shipData = data.GameAccountShipInfo;
                Color prColor = ColorUtils.PrColor(shipData.Pr);
                row.Cells[10].Value = data.Hide ? na : shipData.Pr.ToString();
                row.Cells[10].Style.BackColor = prColor;

                row.Cells[11].Value = data.Hide ? na : shipData.GameWins().ToString("f2") + "%"; ;
                row.Cells[11].Style.ForeColor = ColorUtils.WinsColor(shipData.GameWins());

                row.Cells[12].Value = data.Hide ? na : shipData.GameDamage().ToString();
                row.Cells[13].Value = data.Hide ? na : shipData.Battles.ToString();
                row.Cells[14].Value = shipData.ShipName;
                row.Cells[15].Value = ShipUtils.LevelInfo(shipData.ShipLevel);

                row.Cells[16].Value = data.Hide ? na : data.GameWins().ToString("f2") + "%";
                row.Cells[16].Style.ForeColor = ColorUtils.WinsColor(data.GameWins());

                row.Cells[17].Value = data.Battles;
                row.Cells[18].Value = data.AccountName;
            }
            return row;
        }

        /// <summary>
        /// 整行为PR颜色的模板
        /// </summary>
        /// <param name="i"></param>
        /// <param name="view"></param>
        /// <param name="gameInfoData"></param>
        /// <returns></returns>
        public static DataGridViewRow Two(int i, DataGridView view, GameInfoData gameInfoData)
        {
            string na = "N/A";
            DataGridViewRow row = new DataGridViewRow();
            GameAccountInfoData data;
            if (i < gameInfoData.TeamOneList.Count)
            {
                data = gameInfoData.TeamOneList[i];
                GameAccountShipInfoData shipData = data.GameAccountShipInfo;
                row.CreateCells(view);
                Color prColor = ColorUtils.PrColor(shipData.Pr);
                row.Cells[0].Value = data.AccountName;
                row.Cells[1].Value = data.Battles;
                row.Cells[2].Value = data.Hide ? na : data.GameWins().ToString("f2") + "%";
                row.Cells[3].Value = ShipUtils.LevelInfo(shipData.ShipLevel);
                row.Cells[4].Value = shipData.ShipName;
                row.Cells[5].Value = data.Hide ? na : shipData.Battles.ToString();
                row.Cells[6].Value = data.Hide ? na : shipData.GameDamage().ToString();
                row.Cells[7].Value = data.Hide ? na : shipData.GameWins().ToString("f2") + "%"; ;
                row.Cells[8].Value = data.Hide ? na : shipData.Pr.ToString();
                for (int j = 0; j < 9; j++)
                {
                    row.Cells[j].Style.BackColor = prColor;
                }
            }
            row.Cells[9].Value = "";
            if (i < gameInfoData.TeamTwoList.Count)
            {
                data = gameInfoData.TeamTwoList[i];
                GameAccountShipInfoData shipData = data.GameAccountShipInfo;
                Color prColor = ColorUtils.PrColor(shipData.Pr);
                row.Cells[10].Value = data.Hide ? na : shipData.Pr.ToString();
                row.Cells[11].Value = data.Hide ? na : shipData.GameWins().ToString("f2") + "%"; ;
                row.Cells[12].Value = data.Hide ? na : shipData.GameDamage().ToString();
                row.Cells[13].Value = data.Hide ? na : shipData.Battles.ToString();
                row.Cells[14].Value = shipData.ShipName;
                row.Cells[15].Value = ShipUtils.LevelInfo(shipData.ShipLevel);
                row.Cells[16].Value = data.Hide ? na : data.GameWins().ToString("f2") + "%";
                row.Cells[17].Value = data.Battles;
                row.Cells[18].Value = data.AccountName;
                for (int j = 10; j < 19; j++)
                {
                    row.Cells[j].Style.BackColor = prColor;
                }
            }
            return row;
        }
    }
}
