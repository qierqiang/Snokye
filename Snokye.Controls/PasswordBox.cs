using System.Windows.Forms;

namespace Snokye.Controls
{
    public class PasswordBox:TextBox
    {
        public PasswordBox()
        {
            PasswordChar = '*';
            UseSystemPasswordChar = true;
        }
    }
}
