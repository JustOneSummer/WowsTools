﻿using System;
using System.Drawing;
using System.Windows.Forms;
using WowsTools.model;
using WowsTools.Properties;
using WowsTools.utils;

namespace WowsTools.template
{
    internal class DataGridViewTemplate
    {
        public static Color H_S = Color.FromArgb(105, 105, 105);
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
        public static DataGridViewRow One(int i, DataGridView view, GameInfoData gameInfoData)
        {
            string na = "N/A";
            string rn = Environment.NewLine;
            DataGridViewRow row = new DataGridViewRow();
            GameAccountInfoData data;
            if (i < gameInfoData.TeamOneList.Count)
            {
                data = gameInfoData.TeamOneList[i];
                GameAccountShipInfoData shipData = data.GameAccountShipInfo;
                row.CreateCells(view);
                Color prColor = data.Hide ? H_S : ColorUtils.PrColor(shipData.Pr);
                row.Cells[0].Value = data.AccountName;
                row.Cells[1].Value = data.Battles+ rn + (data.Hide ? na : data.GameWins().ToString("f2") + "%");
                row.Cells[1].Style.ForeColor = ColorUtils.WinsColor(data.GameWins());
                row.Cells[2].Value = ShipUtils.LevelInfo(shipData.ShipLevel) + rn + shipData.ShipName;
                row.Cells[3].Value = (data.Hide ? na : shipData.Battles.ToString()) +rn+(data.Hide ? na : shipData.GameWins().ToString("f2") + "%");
                row.Cells[3].Style.ForeColor = ColorUtils.WinsColor(shipData.GameWins());
                row.Cells[4].Value = data.Hide ? na : shipData.GameDamage().ToString();

                row.Cells[5].Value = data.Hide ? na : shipData.Pr.ToString();
                row.Cells[5].Style.BackColor = prColor;
            }
            row.Cells[6].Value = "";
            if (i < gameInfoData.TeamTwoList.Count)
            {
                data = gameInfoData.TeamTwoList[i];
                GameAccountShipInfoData shipData = data.GameAccountShipInfo;
                Color prColor = data.Hide ? H_S : ColorUtils.PrColor(shipData.Pr);
                row.Cells[7].Value = data.Hide ? na : shipData.Pr.ToString();
                row.Cells[7].Style.BackColor = prColor;
                row.Cells[8].Value = data.Hide ? na : shipData.GameDamage().ToString();
                row.Cells[9].Value = (data.Hide ? na : shipData.Battles.ToString()) + rn + (data.Hide ? na : shipData.GameWins().ToString("f2") + "%");
                row.Cells[9].Style.ForeColor = ColorUtils.WinsColor(shipData.GameWins());
                row.Cells[10].Value = ShipUtils.LevelInfo(shipData.ShipLevel) + rn + shipData.ShipName;

                row.Cells[11].Value = data.Battles + rn + (data.Hide ? na : data.GameWins().ToString("f2") + "%");
                row.Cells[11].Style.ForeColor = ColorUtils.WinsColor(data.GameWins());
                row.Cells[12].Value = data.AccountName;
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
            string rn = Environment.NewLine;
            DataGridViewRow row = new DataGridViewRow();
            GameAccountInfoData data;
            if (i < gameInfoData.TeamOneList.Count)
            {
                data = gameInfoData.TeamOneList[i];
                GameAccountShipInfoData shipData = data.GameAccountShipInfo;
                row.CreateCells(view);
                Color prColor = data.Hide ? H_S : ColorUtils.PrColor(shipData.Pr);
                row.Cells[0].Value = data.AccountName;
                row.Cells[1].Value = data.Battles + rn + (data.Hide ? na : data.GameWins().ToString("f2") + "%");
                row.Cells[2].Value = ShipUtils.LevelInfo(shipData.ShipLevel) + rn + shipData.ShipName;
                row.Cells[3].Value = (data.Hide ? na : shipData.Battles.ToString()) + rn + (data.Hide ? na : shipData.GameWins().ToString("f2") + "%");
                row.Cells[4].Value = data.Hide ? na : shipData.GameDamage().ToString();
                row.Cells[5].Value = data.Hide ? na : shipData.Pr.ToString();
                for (int j = 0; j < 6; j++)
                {
                    row.Cells[j].Style.BackColor = prColor;
                }
            }
            row.Cells[6].Value = "";
            if (i < gameInfoData.TeamTwoList.Count)
            {
                data = gameInfoData.TeamTwoList[i];
                GameAccountShipInfoData shipData = data.GameAccountShipInfo;
                Color prColor = data.Hide ? H_S : ColorUtils.PrColor(shipData.Pr);
                row.Cells[7].Value = data.Hide ? na : shipData.Pr.ToString();
                row.Cells[8].Value = data.Hide ? na : shipData.GameDamage().ToString();
                row.Cells[9].Value = (data.Hide ? na : shipData.Battles.ToString()) + rn + (data.Hide ? na : shipData.GameWins().ToString("f2") + "%");
                row.Cells[10].Value = ShipUtils.LevelInfo(shipData.ShipLevel) + rn + shipData.ShipName;
                row.Cells[11].Value = data.Battles + rn + (data.Hide ? na : data.GameWins().ToString("f2") + "%");
                row.Cells[12].Value = data.AccountName;
                for (int j = 7; j < 13; j++)
                {
                    row.Cells[j].Style.BackColor = prColor;
                }
            }
            return row;
        }
    }
}
