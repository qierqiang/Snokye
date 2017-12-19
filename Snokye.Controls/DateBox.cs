using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snokye.Controls
{
    public class DateBox:DateTimePicker
    {
        public DateBox()
        {
            Format = DateTimePickerFormat.Custom;
            CustomFormat = "yyyy-MM-dd";
        }

    }
}
