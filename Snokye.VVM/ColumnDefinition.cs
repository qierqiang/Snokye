using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snokye.VVM
{
    public struct ColumnDefinition
    {
        public string GroupName { get; set; }
        public Type ColumnType { get; set; }
        public string Title { get; set; }
        public string DataPropertyName { get; set; }
        public string Name { get; set; }
        public int Width { get; set; }
        public DataGridViewColumnSortMode SortMode { get; set; }
        public SortOrder SortOrder { get; set; }
        public bool Visible { get; set; }
        public int Index { get; set; }
        public bool Frozen { get; set; }

        public ColumnDefinition(Type columnType, string title, string groupName = null, string dataPropertyName = null,
            string name = null, int width = 100, DataGridViewColumnSortMode sortMode = DataGridViewColumnSortMode.Programmatic, SortOrder sortOrder = SortOrder.None, bool visible = true, int index = -1, bool frozen = false)
        {
            GroupName = groupName;
            ColumnType = (columnType ?? throw new ArgumentNullException(nameof(columnType)))
                .IsSubclassOf(typeof(DataGridViewColumn)) ? columnType :
                throw new ArgumentException(columnType.ToString() + "不是有效的DataGridViewColumn!", nameof(columnType));
            Title = title;
            DataPropertyName = dataPropertyName;
            Name = name;
            Width = width;
            SortMode = sortMode;
            SortOrder = sortOrder;
            Visible = visible;
            Index = index;
            Frozen = frozen;
        }
    }
}
