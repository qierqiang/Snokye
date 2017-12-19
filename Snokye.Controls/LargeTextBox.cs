using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snokye.Controls
{
    public class LargeTextBox:TextBox
    {
        public LargeTextBox()
        {
            Multiline = true;
            ScrollBars = ScrollBars.Both;
        }
    }
}
