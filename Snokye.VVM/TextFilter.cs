using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Snokye.Utility;

namespace Snokye.VVM
{
    public partial class TextFilter : FilterControlBase
    {
        public TextFilter()
        {
            InitializeComponent();
            FilterOperator = "LIKE";
        }

        public override KeyValuePair<string, SqlParameter[]>? GetFilter()
        {
            if (DataPropertyName.IsNullOrWhiteSpace())
                throw new Exception(Title + ".DataPropertyName属性尚未初始化！");

            if (txt.Text.Trim().Length == 0)
                return null;

            string parmName = '@' + DataPropertyName.Replace(".", "");
            string filter = string.Format("[{0}] {1} {2}", DataPropertyName.Replace(".", "].["), FilterOperator, parmName);
            SqlParameter[] parms = new SqlParameter[] { new SqlParameter(parmName, '%' + txt.Text + '%') };
            return new KeyValuePair<string, SqlParameter[]>(filter, parms);
        }
    }
}
