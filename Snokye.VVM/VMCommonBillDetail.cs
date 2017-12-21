using Snokye.VVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snokye.VVM
{
    public abstract class VMCommonBillDetail : MappedViewModelBase
    {
        public long ID { get; set; }

        public long BillID { get; set; }
    }
}
