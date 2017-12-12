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
            //CombinedGridView combinedGridView1 = new CombinedGridView();
            //combinedGridView1.Location = new Point(200, 200);
            //Controls.Add(combinedGridView1);
            //for (int i = 0; i < 100; i++)
            //{
            //    combinedGridView1.LeftDataGridView.Rows.Add(i.ToString());
            //    combinedGridView1.RightDataGridView.Rows.Add(i.ToString());
            //}




            pagingControl1.Init(1024);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            pagingControl1.CurrentPage++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pagingControl1.CurrentPage--;
        }
    }
}
