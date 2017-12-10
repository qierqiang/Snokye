using Snokye.Utility;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Snokye.Controls
{
    //BUG:刚显示时不显示水印
    public class WatermarkTextBox : TextBox
    {
        //watermark
        public event EventHandler WatermarkChanged;

        private string _watermark;

        public string Watermark
        {
            get { return _watermark; }
            set
            {
                if (_watermark != value)
                {
                    _watermark = value;
                    OnWatermarkChanged();
                }
            }
        }

        protected virtual void OnWatermarkChanged()
        {
            WatermarkChanged?.Invoke(this, EventArgs.Empty);
        }

        protected override void WndProc(ref Message m)
        {
            //TextBox是由系统进程绘制，重载OnPaint方法将不起作用
            if (m.Msg == 0xF || m.Msg == 0x133)
            {
                if (Text.IsNullOrEmpty() && !Watermark.IsNullOrWhiteSpace() && !Focused)
                {
                    Graphics graphics = Graphics.FromHwnd(base.Handle);
                    graphics.DrawString(Watermark, Font, new SolidBrush(SystemColors.GrayText), 0, 0);
                }
            }
            base.WndProc(ref m);
        }
    }
}
