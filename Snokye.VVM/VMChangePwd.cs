using Snokye.Controls;
using Snokye.Utility;
using Snokye.VVM.Model;
using System.Linq;

namespace Snokye.VVM
{
    public class VMChangePwd : ViewModelBase
    {
        public long ID { get; set; }

        [Validate]
        [AutoGenControl(typeof(PasswordBox), "原密码")]
        public string OldPassword { get; set; }

        [Validate]
        [AutoGenControl(typeof(PasswordBox), "新密码", beginNewRow: true)]
        public string NewPasswrod { get; set; }

        [Validate]
        [AutoGenControl(typeof(PasswordBox), "确认密码", beginNewRow: true)]
        public string RepPassword { get; set; }

        public override bool BeforeSubmit()
        {
            if (!base.BeforeSubmit())
            {
                return false;
            }
            if (NewPasswrod != RepPassword)
            {
                ValidateFailed?.Invoke(nameof(RepPassword), "两次输入的密码不一致！");
                return false;
            }
            using (SnokyeContainer c = new SnokyeContainer())
            {
                var query = from u in c.UserInfoSet
                            where u.Id == ClientInfo.CurrentUser.Id
                            select u.Password;
                if (OldPassword.GetMD5() != query.FirstOrDefault())
                {
                    ValidateFailed?.Invoke(nameof(OldPassword), "原密码不正确！");
                    return false;
                }
            }
            return true;
        }

        public override bool Submit()
        {
            if (!base.Submit())
                return false;

            using (SnokyeContainer c = new SnokyeContainer())
            {
                c.UserInfoSet.Where(u => u.Id == ClientInfo.CurrentUser.Id).First().Password = NewPasswrod.GetMD5();
                c.SaveChanges();
            }
            return true;
        }
    }
}
