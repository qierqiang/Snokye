using SalesmenSettlement.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Snokye.Controls;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CombinedGridView combinedGridView1 = new CombinedGridView();
            combinedGridView1.Location = new Point(200, 200);
            Controls.Add(combinedGridView1);
            //for (int i = 0; i < 100; i++)
            //{
            //    combinedGridView1.LeftDataGridView.Rows.Add(i.ToString());
            //    combinedGridView1.RightDataGridView.Rows.Add(i.ToString());
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(combinedGridView1.LeftDataGridView.Width.ToString());
            Controls.Remove(this.FindFirstChildControl(c=>c is CombinedGridView));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form1().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
