using Snokye.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snokye.VVM.Model
{
    partial class UserInfo
    {
        public UserInfo()
        {
            UserGuid = Guid.NewGuid();
            Password = "123456".GetMD5();
        }
    }
}
