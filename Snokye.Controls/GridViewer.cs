using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SalesmenSettlement.Forms
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
            MultiSelect = false;
            ReadOnly = true;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle(ColumnHeadersDefaultCellStyle) { Alignment = DataGridViewContentAlignment.MiddleCenter };
        }
    }
}
