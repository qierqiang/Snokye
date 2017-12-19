using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snokye.Controls
{
    public class DecimalBox:NumericUpDown
    {
        public DecimalBox()
        {
            Minimum = decimal.MinValue;
            Maximum = decimal.MaxValue;
            DecimalPlaces = 4;
        }
    }
}
