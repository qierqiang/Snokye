using Snokye.Controls;
using Snokye.VVM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snokye.VVM
{
    public abstract class VMCommonBill<T> : MappedViewModelBase, IBillViewModel where T : VMCommonBillDetail
    {
        //properties
        public long ID { get; set; }

        [AutoGenControl(EditorType = typeof(TextBox), DisplayName = "编号", ReadOnlyWhenCreate = true, ReadOnlyWhenModify = true)]
        public string Number { get; set; }

        public long BillerID { get; set; }

        [AutoGenControl(EditorType = typeof(TextBox), DisplayName = "制单人", ReadOnlyWhenCreate = true, ReadOnlyWhenModify = true)]
        public long BillerName { get; set; }

        [AutoGenControl(EditorType = typeof(DateBox), DisplayName = "制单日期", ReadOnlyWhenCreate = true, ReadOnlyWhenModify = true)]
        public DateTime CreateDate { get; set; }

        [AutoGenControl(EditorType = typeof(TextBox), DisplayName = "状态", ReadOnlyWhenCreate = true, ReadOnlyWhenModify = true)]
        public string StatusName { get; set; }

        //public
        public Type GetDetailModelType() => typeof(T);

        public abstract IBindingList GetDetails();

        public abstract ViewModelBase NewDetail();
    }
}
