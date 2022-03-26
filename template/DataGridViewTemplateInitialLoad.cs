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
    }
}
