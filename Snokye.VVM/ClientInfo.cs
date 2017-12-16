using Snokye.VVM.Model;
using System.Collections;

namespace Snokye.VVM
{
    public static class ClientInfo
    {
        static ClientInfo()
        {
            Directory = new Hashtable();
        }

        public static UserInfo CurrentUser { get; set; }

        public static ServerUserProfile UserProfile { get; set; }

        public static ClientForm ClientForm { get; set; }

        public static Hashtable Directory { get; private set; }
    }
}
