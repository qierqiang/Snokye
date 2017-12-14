using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Snokye.Controls;
using System.Data.SqlClient;

namespace Snokye.VVM
{
    public partial class FilterBar : UserControl, ISupportInitialize
    {
        public event Action<string, SqlParameter[]> Filtering;

        //private bool _expanded = true;

        public string FilterString { get; set; }
        public SqlParameter[] Parameters { get; set; }

        public FilterBar()
        {
            InitializeComponent();

            foreach (RadioButton r in this.FindChildControl(c => c is RadioButton).OfType<RadioButton>())
                r.CheckedChanged += RadioButton_CheckedChanged;
        }

        protected virtual void BuildFilter()
        {
            throw new NotImplementedException();
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!DesignMode && sender is RadioButton r && r.Checked)
            {
                BuildFilter();
                Filtering?.Invoke(FilterString, Parameters);
            }
        }

        private void bFilter_Click(object sender, EventArgs e)
        {
            BuildFilter();
            Filtering?.Invoke(FilterString, Parameters);
        }

        private void bAdvFilter_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(_expanded.ToString());
            //if (_expanded)
            //{
            //    Height = MinimumSize.Height;
            //    bAdvFilter.Text = "6";
            //}
            //else
            //{
            //    Height = MaximumSize.Height;
            //    bAdvFilter.Text = "5";
            //}
            //_expanded = !_expanded;
        }

        #region ISupportInitialize

        public void BeginInit() { }

        public void EndInit()
        {
            //MaximumSize = new Size(0, Height);
            //bAdvFilter_Click(bAdvFilter, EventArgs.Empty);
        }

        #endregion
    }
}
