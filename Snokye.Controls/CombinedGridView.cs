using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Snokye.Controls
{
    public partial class CombinedGridView : UserControl, ISupportInitialize
    {
        public DataGridView LeftDataGridView { get => dataGridView1; }

        public DataGridView RightDataGridView { get => dataGridView2; }

        protected ScrollBar LeftHScrollBar { get => leftScrollbar; }
        protected ScrollBar RightHScrollBar { get; private set; }
        protected ScrollBar LeftVScrollBar { get; private set; }
        protected ScrollBar RightVScrollBar { get; private set; }

        public CombinedGridView()
        {
            InitializeComponent();
            LeftDataGridView.SyncSelectedRowIndex(RightDataGridView);
            LeftDataGridView.SyncVerticalScroll(RightDataGridView);
            LeftDataGridView.SyncRowHeight(RightDataGridView);

            //set scrollbar properties
            RightHScrollBar = (ScrollBar)typeof(DataGridView).GetProperty("HorizontalScrollBar", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(RightDataGridView, null);
            PropertyInfo property = typeof(DataGridView).GetProperty("VerticalScrollBar", BindingFlags.NonPublic | BindingFlags.Instance);
            LeftVScrollBar = (ScrollBar)property.GetValue(LeftDataGridView, null);
            RightVScrollBar = (ScrollBar)property.GetValue(RightDataGridView, null);

            //HScroll
            RightHScrollBar.VisibleChanged += (object sender, EventArgs e) => LeftHScrollBar.Visible = RightHScrollBar.Visible;
            RightHScrollBar.SizeChanged += (object sender, EventArgs e) => LeftHScrollBar.Height = RightHScrollBar.Height;
            //VScroll
            LeftHScrollBar.VisibleChanged += (object sender, EventArgs e) => PerformLayoutPrivate();
            LeftVScrollBar.VisibleChanged += (object sender, EventArgs e) => PerformLayoutPrivate();
        }

        private void PerformLayoutPrivate()
        {
            LeftDataGridView.Dock = DockStyle.None;
            LeftDataGridView.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            LeftDataGridView.Location = Point.Empty;
            LeftDataGridView.Width = LeftDataGridView.Parent.ClientSize.Width + (LeftVScrollBar.Visible ? LeftVScrollBar.Width : 0);
            LeftDataGridView.Height = LeftDataGridView.Parent.ClientSize.Height - (LeftHScrollBar.Visible ? LeftHScrollBar.Height : 0);
        }

        public void BeginInit()
        {
            this.SuspendLayout();
        }

        public void EndInit()
        {
            PerformLayoutPrivate();
            ResumeLayout(false);
        }

        private void CombinedGridView_Load(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance++;
        }
    }
}
