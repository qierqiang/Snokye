using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Snokye.Controls;

namespace Snokye.VVM
{
    public partial class DataList : UserControl
    {
        private List<string> SqlList = new List<string>();

        public bool IsSelectMode
        {
            get => panelSelect.Visible;
            set
            {
                if (value != panelSelect.Visible)
                {
                    if (panelSelect.Visible)
                        SetSelectMode();
                    else
                        SetNotSelectMode();

                    panelSelect.Visible = value;
                }
            }
        }

        public DataList()
        {
            InitializeComponent();
            //bSelect.Location = new Point((panelSelect.Width - bSelect.Width) / 2, 5);
        }

        private void SetSelectMode()
        {
            foreach (DataGridView dgv in this.FindChildControl(c => c is DataGridView))
            {
                throw new NotImplementedException();
            }
        }

        private void SetNotSelectMode()
        {
            throw new NotImplementedException();
        }

        private void SyncSelection()
        {

        }
    }
}
