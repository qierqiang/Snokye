using System;
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
    }
}
