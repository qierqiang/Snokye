using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Snokye.VVM
{
    public partial class FilterControlBase : UserControl
    {
        public FilterControlBase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 过滤条件字段名，可以写成t1.Name的形式
        /// </summary>
        public string DataPropertyName { get; set; }

        /// <summary>
        /// 过滤条件名称，如：单据编号
        /// </summary>
        public string Title { get => lTitle.Text; set => lTitle.Text = value; }

        /// <summary>
        /// 过滤条件运算符，如：=  LIKE 等等
        /// </summary>
        public string FilterOperator { get; set; }

        /// <summary>
        /// 获取过滤条件，如Key="t1.Name LIKE @t1Name", Value=new SqlParameter("@t1Name", "someText")
        /// </summary>
        public virtual KeyValuePair<string, SqlParameter[]>? GetFilter()
        {
            throw new NotImplementedException();
        }
    }
}
