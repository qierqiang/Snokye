using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                combinedGridView1.LeftDataGridView.Rows.Add(i.ToString());
                combinedGridView1.RightDataGridView.Rows.Add(i.ToString());
            }

            combinedGridView1.Invalidate(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(combinedGridView1.LeftDataGridView.Width.ToString());
        }
    }
}
