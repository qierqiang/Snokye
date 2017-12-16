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
    public partial class DateRangeFilter : FilterControlBase
    {

        public DateRangeFilter()
        {
            InitializeComponent();
        }

        public override KeyValuePair<string, SqlParameter[]>? GetFilter()
        {
            if (DataPropertyName.IsNullOrWhiteSpace())
                throw new Exception(Title + ".DataPropertyName属性尚未初始化！");

            if (!dtpStart.Checked && !dtpStop.Checked)
                return null;

            string filter = null;
            List<SqlParameter> parms = new List<SqlParameter>();
            string startParmName = "@start" + DataPropertyName.Replace(".", "");
            string stopParmName = "@stop" + DataPropertyName.Replace(".", "");

            if (dtpStart.Checked && dtpStop.Checked)
            {
                filter = string.Format("[{0}] >= {1} AND [{0}] < {2}", DataPropertyName.Replace(".", "].["), startParmName, stopParmName);
                parms.Add(new SqlParameter(startParmName, dtpStart.Value.Date));
                parms.Add(new SqlParameter(stopParmName, dtpStop.Value.AddDays(1).Date));
            }
            if (dtpStart.Checked && !dtpStop.Checked)
            {
                filter = string.Format("[{0}] >= {1}", DataPropertyName.Replace(".", "].["), startParmName);
                parms.Add(new SqlParameter(startParmName, dtpStart.Value.Date));
            }
            if (!dtpStart.Checked && dtpStop.Checked)
            {
                filter = string.Format("[{0}] < {1}", DataPropertyName.Replace(".", "].["), stopParmName);
                parms.Add(new SqlParameter(stopParmName, dtpStop.Value.AddDays(1).Date));
            }

            return new KeyValuePair<string, SqlParameter[]>(filter, parms.ToArray());
        }
    }
}
