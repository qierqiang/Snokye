﻿using System.Drawing;
using System.Windows.Forms;
using Snokye.Utility;
using Snokye.Controls;

namespace Snokye.VVM
{
    public class FormState
    {
        public FormWindowState WindowState { get; set; }

        public Point Location { get; set; }

        public Size Size { get; set; }

        public static void LoadFormState(Form frm, string title, ViewModelBase vm = null)
        {
            string profileName = (frm.GetType().FullName + "_" + title + (vm == null ? "" : vm.GetType().FullName));
            FormState profile = LocalUserProfile.GetProfile<FormState>(ClientInfo.UserLoginName, profileName);

            if (profile != null)
            {
                frm.WindowState = profile.WindowState;
                if (frm.WindowState != FormWindowState.Maximized)
                {
                    frm.StartPosition = FormStartPosition.Manual;
                    frm.Location = profile.Location;
                    frm.Size = profile.Size;
                }
            }
        }

        public static void SaveFormState(Form frm, string title, ViewModelBase vm = null)
        {
            string profileName = (frm.GetType().FullName + "_" + title + (vm == null ? "" : vm.GetType().FullName));
            FormState profile = new FormState { WindowState = frm.WindowState, Location = frm.Location, Size = frm.Size };
            LocalUserProfile.Save(ClientInfo.UserLoginName, profileName, profile);
        }
    }
}
