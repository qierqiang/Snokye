using System;
using System.Windows.Forms;
using CD = Snokye.VVM.ColumnDefinition;
using FD = Snokye.VVM.FilterDefinition;

namespace Snokye.VVM
{
    public partial class UserManage : DataListBase
    {
        public UserManage() : base(typeof(VMEditUser), typeof(AutoEditForm), typeof(AutoEditForm), "用户")
        {
            InitializeComponent();
        }

        public override void BeginInit()
        {
            base.BeginInit();

            Sentence_From = "UserInfoSet AS t1";
            FilterDefinitions.AddRange(new FD[]{
                new FD(typeof(TextFilter), "t1.UserName", "用户名"),
                new FD(typeof(TextFilter), "t1.DisplayName", "姓名"),
            });
            ColumnDefinitions.AddRange(new CD[]
            {
                new CD(typeof(DataGridViewTextBoxColumn),  "用户名", null, "t1.UserName",    "colUserName",    200),
                new CD(typeof(DataGridViewTextBoxColumn),  "姓名",   null, "t1.DisplayName", "colDisplayName", 200),
                new CD(typeof(DataGridViewCheckBoxColumn), "禁用",   null, "t1.Disabled",    "colDisabled",    35),
            });
        }

        public override void EndInit()
        {
            base.EndInit();
            AllGridView.ForEach(d => d.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill);
        }
    }
}
