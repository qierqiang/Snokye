using System.Windows.Forms;
using Snokye.Utility;

namespace Snokye.Controls
{
    public class GridViewer : DataGridView
    {
        public GridViewer()
        {
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToResizeRows = false;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            RowHeadersWidth = 22;
            RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            MultiSelect = false;
            ReadOnly = true;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle(ColumnHeadersDefaultCellStyle) { Alignment = DataGridViewContentAlignment.MiddleCenter };
        }

        protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
        {
            base.OnDataBindingComplete(e);

            foreach (DataGridViewColumn c in Columns)
            {
                if (c.ValueType.IsNumericType())
                {
                    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }
    }
}
