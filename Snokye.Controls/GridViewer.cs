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

            ////选择列
            //DataGridViewCheckBoxColumn cbc = new DataGridViewCheckBoxColumn { Visible = false };
            //Columns.Add(cbc);

            ////标识列
            //DataGridViewTextBoxColumn idc = new DataGridViewTextBoxColumn { Visible = false };
            //Columns.Add(idc);
        }
    }
}
