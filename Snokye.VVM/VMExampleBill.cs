using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Snokye.Utility;
using Snokye.VVM.Model;

namespace Snokye.VVM
{
    public class VMExampleBill : MappedViewModelBase, IBillViewModel
    {
        public List<VMExampleBillDetail> _details = new List<VMExampleBillDetail> { new VMExampleBillDetail(), };

        [AutoGenControl(EditorType = typeof(TextBox), DisplayName = "编号", GroupName = "1")]
        public string Number { get; set; }

        [AutoGenControl(EditorType = typeof(TextBox), DisplayName = "编号", GroupName = "2")]
        public string Name { get; set; }

        [AutoGenControl(EditorType = typeof(TextBox), DisplayName = "编号", GroupName = "3")]
        public string Test { get; set; }
        [AutoGenControl(EditorType = typeof(TextBox), DisplayName = "编号", GroupName = "4")]
        public string Test1 { get; set; }

        public override void LoadByID(long id)
        {
            Number = "0001";
            _details.ForEach(d => d.LoadByID(id));
        }

        IList IBillViewModel.GetDetails() => _details;
    }

    public class VMExampleBillDetail : MappedViewModelBase
    {
        public long ID { get; set; }

        public string DetailName { get; set; }

        [AutoGenColumn(DisplayName = "aaa")]
        public int Value { get; set; }

        public override void LoadByID(long id)
        {
            id = 222;
            DetailName = "fdsjfilsjfidsjfl";
        }
    }
}
