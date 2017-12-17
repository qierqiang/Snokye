using Snokye.VVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Snokye.Controls;
using System.Windows.Forms;
using Snokye.Utility;

namespace Snokye.VVM
{
    public class VMEditUser : MappedViewModelBase
    {
        [Validate]
        [AutoGenControl(typeof(TextBox), "用户名")]
        public string UserName { get; set; }

        [Validate]
        [AutoGenControl(typeof(TextBox), "姓名")]
        public string DisplayName { get; set; }

        UserInfo _eneity;
        SnokyeContainer _container = new SnokyeContainer();

        public override void LoadByID(long id)
        {
            if (id < 1)
            {
                //_eneity = UserInfo.CreateUserInfo(0, "", "", "123456".GetMD5(), Guid.NewGuid());
                _eneity = new UserInfo();
            }
            else
            {
                _eneity = _container.UserInfoSet.FirstOrDefault(u => u.Id == id) ?? new UserInfo();
            }

            Map(nameof(UserName), _eneity, () => _eneity.UserName);
            Map(nameof(DisplayName), _eneity, () => _eneity.DisplayName);
            ReadMappedPropertyValues();
        }

        public override bool Submit()
        {
            if (!base.Submit())
                return false;

            _container.SaveChanges();
            return true;
        }
    }
}
