using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Snokye.Controls
{
    public static class ControlHelper
    {
        public static void ShowError(this ErrorProvider provider, Control ctrl, string error)
        {
            provider.SetError(ctrl, error);
            ctrl.Focus();
            EventHandler action = null;
            action = (object sender, EventArgs e) =>
            {
                provider.Clear();
                ctrl.TextChanged -= action;
            };
            ctrl.TextChanged += action;
        }

        public static Control FindFirstChildControl(this Control container, Func<Control, bool> filter)
        {
            foreach (Control c in container.Controls)
            {
                if (filter(c))
                    return c;

                Control result = FindFirstChildControl(c, filter);
                if (result != null)
                    return result;
            }

            return null;
        }

        public static IEnumerable<Control> FindChildControl(this Control container, Func<Control, bool> filter)
        {
            foreach (Control c in container.Controls)
            {
                if (filter(c))
                    yield return c;

                foreach (var item in FindChildControl(c, filter))
                {
                    yield return item;
                }
            }
        }
    }
}
