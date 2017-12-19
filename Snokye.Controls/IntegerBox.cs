using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snokye.Controls
{
    public class IntegerBox : NumericUpDown
    {
        public IntegerBox()
        {
            Minimum = int.MinValue;
            Maximum = int.MaxValue;
            DecimalPlaces = 0;
        }
    }
}
