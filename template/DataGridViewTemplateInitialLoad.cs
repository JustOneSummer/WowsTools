using System;
using System.Drawing;
using System.Windows.Forms;

namespace WowsTools.template
{
    internal class DataGridViewTemplateInitialLoad
    {
        public static DataGridView Load(DataGridView view)
        {
            view.RowHeadersVisible = false;
            view.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            view.Columns.Add("userNameOne", "玩家");
            view.Columns.Add("BattlesOneuserWinsOne", "场次/胜率");
            view.Columns.Add("levelOneShipNameOne", "场均/名称");
            view.Columns.Add("shipBattlesOneShipWinsOne", "场次/胜率");
            view.Columns.Add("ShipPrOne", "评分");
            view.Columns["ShipPrOne"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            view.Columns["shipBattlesOneShipWinsOne"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            view.Columns["levelOneShipNameOne"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            view.Columns["BattlesOneuserWinsOne"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            view.Columns["userNameOne"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            view.Columns["ShipPrOne"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            view.Columns["shipBattlesOneShipWinsOne"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            view.Columns["levelOneShipNameOne"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            view.Columns["BattlesOneuserWinsOne"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            view.Columns["userNameOne"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            view.Columns.Add("AB", "A/B");
            view.Columns["AB"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            view.Columns.Add("ShipPrTwo", "评分");
            view.Columns.Add("shipBattlesOneShipWinsTwo", "场次/胜率");
            view.Columns.Add("levelOneShipNameTwo", "场均/名称");
            view.Columns.Add("BattlesOneuserWinsTwo", "场次/胜率");
            view.Columns.Add("userNameTwo", "玩家");
            view.Columns["ShipPrTwo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            view.Columns["shipBattlesOneShipWinsTwo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            view.Columns["levelOneShipNameTwo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            view.Columns["BattlesOneuserWinsTwo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            view.Columns["userNameTwo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //view.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //view.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            view.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            view.AllowUserToAddRows = false;
            view.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            view.ClearSelection();
            view.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            return view;
        }

        /// <summary>
        /// 界面行宽
        /// </summary>
        public static DataGridView Hw(DataGridView view)
        {
            view.Columns[0].FillWeight = 30;
            view.Columns[1].FillWeight = 11;
            view.Columns[2].FillWeight = 18;
            view.Columns[3].FillWeight = 11;
            view.Columns[4].FillWeight = 9;

            view.Columns[5].FillWeight = 5;

            view.Columns[6].FillWeight = 9;
            view.Columns[7].FillWeight = 11;
            view.Columns[8].FillWeight = 18;
            view.Columns[9].FillWeight = 11;
            view.Columns[10].FillWeight = 30;
            for (int i = 0; i < view.Columns.Count; i++)
            {
                view.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                view.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            for (int i = 0; i < view.Rows.Count; i++)
            {
                view.Rows[i].Height = 55;
                if (i == 0)
                {
                    view.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(Convert.ToInt32("ffF8F8FF", 16));
                }
            }
            return view;
        }
    }
}
