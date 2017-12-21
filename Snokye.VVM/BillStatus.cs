using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snokye.VVM
{
    public static class BillStatus
    {
        public const string Editing = "编辑中";
        public const string Checking = "待审核";
        public const string CheckFail = "审核不通过";
        public const string Checked = "已审核";
    }
}
