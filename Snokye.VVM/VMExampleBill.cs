using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Snokye.Controls;
using Snokye.Utility;
using Snokye.VVM.Model;

namespace Snokye.VVM
{
    public class VMExampleBill : MappedViewModelBase, IBillViewModel
    {
        BindingList<VMExampleBillDetail> _details = new BindingList<VMExampleBillDetail>();// { new VMExampleBillDetail(), };

        [AutoGenControl(EditorType = typeof(TextBox), DisplayName = "编号", ReadOnlyWhenCreate = true, ReadOnlyWhenModify = true)]
        public string Number { get; set; }

        [AutoGenControl(EditorType = typeof(DateBox), DisplayName = "日期", ReadOnlyWhenCreate = true, ReadOnlyWhenModify = true)]
        public DateTime CreateDate { get; set; }

        [AutoGenControl(EditorType = typeof(TextBox), DisplayName = "制单人", ReadOnlyWhenCreate = true, ReadOnlyWhenModify = true)]
        public string BillerName { get; set; }

        [AutoGenControl(EditorType = typeof(TextBox), DisplayName = "状态", ReadOnlyWhenCreate = true, ReadOnlyWhenModify = true)]
        public string StatusName { get; set; }

        public override void LoadByID(long id)
        {
            if (id > 0)
            {
                Number = "0001";
                CreateDate = DateTime.Today;
                BillerName = ClientInfo.CurrentUser.DisplayName;
                StatusName = "编辑中";

                using (SnokyeContainer c = new SnokyeContainer())
                {
                    UserInfo[] users = c.UserInfoSet.Where((u) => true).ToArray();
                    foreach (UserInfo u in users)
                    {
                        VMExampleBillDetail d = new VMExampleBillDetail
                        {
                            ID = id,
                            UserID = u.Id,
                            UserName = u.UserName,
                        };
                        d = ViewModelProxy.Proxy(d);
                        _details.Add(d);
                    }
                }
            }
        }

        public Type GetDetailModelType() => typeof(VMExampleBillDetail);

        public IBindingList GetDetails() => _details;

        public ViewModelBase NewDetail()
        {
            VMExampleBillDetail d = new VMExampleBillDetail();
            d = ViewModelProxy.Proxy(d);
            _details.Add(d);
            return d;
        }
    }

    public class VMExampleBillDetail : MappedViewModelBase
    {
        public VMExampleBillDetail()
        {
            UserInfo userInfo = new UserInfo();
            Map(nameof(ID), userInfo, () => userInfo.Id);
            Map(nameof(UserID), userInfo, () => userInfo.Id);
            Map(nameof(UserName), userInfo, () => userInfo.UserName);
            Map(nameof(DisplayName), userInfo, () => userInfo.DisplayName);
            ReadMappedPropertyValues();
        }

        public long ID { get; set; }

        public long UserID { get; set; }

        [AutoGenColumn(DisplayName = "用户", ColumnType = typeof(DataGridViewButtonColumn), SelectFormType = typeof(UserManage))]
        public string UserName { get; set; }

        [AutoGenColumn(DisplayName = "姓名", ReadOnlyWhenCreate = true, ReadOnlyWhenModify = true)]
        public string DisplayName { get; set; }

        public override void LoadByID(long id)
        {

        }
    }
}
