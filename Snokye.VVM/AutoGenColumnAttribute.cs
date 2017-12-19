using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snokye.VVM
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class AutoGenColumnAttribute : Attribute
    {
        public Type ColumnType { get; set; }

        public Type SelectFormType { get; set; }

        public string DisplayName { get; set; }

        public int DefaultWidth { get; set; }

        public bool ReadOnlyWhenCreate { get; set; }

        public bool ReadOnlyWhenModify { get; set; }

        public AutoGenColumnAttribute()
        {
            ColumnType = typeof(DataGridViewTextBoxColumn);
            DefaultWidth = 100;
        }
    }
}
