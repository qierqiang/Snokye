using Snokye.Utility;
using Snokye.VVM.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Text;

namespace Snokye.VVM
{
    public class VMLoginForm : ViewModelBase
    {
        private Dictionary<string, string> _userHistory = new Dictionary<string, string>();

        public VMLoginForm()
        {
            //加载登录记录
            //只加载最近10个
            var dirs = new DirectoryInfo(LocalUserProfile.UserProfileDirecotry).GetDirectories().OrderByDescending(d => d.LastWriteTime).Take(10);

            foreach (var d in dirs)//每个目录一个用户（的所有设置）
            {
                //找密码
                string pwd = LocalUserProfile.GetProfileContent(d.Name, "password");
                _userHistory[d.Name] = pwd;
            }
            UserHistory = _userHistory.Keys.ToArray();
            if (UserHistory.Length > 0)
            {
                UserName = UserHistory[0];
                Password = _userHistory[UserName];
                RememberPwd = Password != null;
            }
        }

        public string[] UserHistory { get; private set; }

        [Validate]
        [AutoGenControl(EditorType = typeof(ComboBox))]
        public string UserName { get; set; }

        [Validate]
        [AutoGenControl(EditorType = typeof(TextBox))]
        public string Password { get; set; }

        [AutoGenControl(EditorType = typeof(CheckBox))]
        public bool ClearLogin { get; set; }

        [AutoGenControl(EditorType = typeof(CheckBox))]
        public bool RememberPwd { get; set; }

        public override bool Submit()
        {
            if (!base.Submit())
            {
                return false;
            }

            using (SnokyeContainer container = new SnokyeContainer())
            {
                string hashValue = Password.GetMD5();
#if DEBUG
                if (!container.UserInfoSet.Any())
                {
                    UserInfo __admin = new UserInfo { DisplayName = "系统管理员", Password = "123456".GetMD5(), UserName = "admin", UserGuid = Guid.NewGuid() };
                    container.AddToUserInfoSet(__admin);

                    for (int i = 0; i < 100; i++)
                    {
                        //0xB0A1 - 0xF7FE
                        UserInfo u = new UserInfo
                        {
                            UserName = "User" + i,
                            DisplayName = "User" + i,
                            Password = "123456".GetMD5()
                        };
                        container.AddToUserInfoSet(u);

                        container.SaveChanges();
                    }
                }
#endif
                var user = container.UserInfoSet.FirstOrDefault(u => u.UserName == UserName && u.Password == hashValue);

                if (user == null)
                {
                    ValidateFailed?.Invoke(nameof(UserName), "用户名不存在或密码错误！");
                    return false;
                }
                if (user.Disabled)
                {
                    ValidateFailed?.Invoke(nameof(UserName), "该用户已被禁用！");
                    return false;
                }

                ClientInfo.CurrentUser = user;
                ClientInfo.UserProfile = new ServerUserProfile(user.UserGuid);
            }

            if (RememberPwd)
            {
                LocalUserProfile.SaveContent(UserName, "password", Password);
            }
            else
            {
                LocalUserProfile.Delete(UserName, "password");
            }
            return true;
        }

        public override void OnPropertyChanged(string propertyName)
        {
            if (propertyName == nameof(UserName))
            {
                if (_userHistory.ContainsKey(UserName))
                {
                    string pwd = _userHistory[UserName];
                    if (pwd != null)
                    {
                        Password = pwd;
                        RememberPwd = true;
                    }
                    else
                    {
                        Password = string.Empty;
                        RememberPwd = false;
                    }
                }
                else
                {
                    Password = string.Empty;
                    RememberPwd = false;
                }
            }
            else if (propertyName == nameof(ClearLogin))
            {
                if (ClearLogin)
                    RememberPwd = false;
            }
            else if (propertyName == nameof(RememberPwd))
            {
                if (RememberPwd)
                    ClearLogin = false;
            }

            base.OnPropertyChanged(propertyName);
        }
    }
}
