using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Snokye.Controls;
using System.Reflection;

namespace SalesmenSettlement.Forms
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
            SyncSelectedRowIndex(LeftDataGridView, RightDataGridView);
            SyncVerticalScroll(LeftDataGridView, RightDataGridView);
            SyncRowHeight(LeftDataGridView, RightDataGridView);

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

        private void LeftDataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            //if (LeftDataGridView.PerformLayout)
        }

        private static void SyncVerticalScroll(DataGridView gridView1, DataGridView gridView2)
        {
            void gridView1Scroll(object sender, ScrollEventArgs e)
            {
                if (gridView2.FirstDisplayedScrollingRowIndex != gridView1.FirstDisplayedScrollingRowIndex)
                    try { gridView2.FirstDisplayedScrollingRowIndex = gridView1.FirstDisplayedScrollingRowIndex; } catch { }
            }

            void gridView2Scroll(object sender, ScrollEventArgs e)
            {
                if (gridView1.FirstDisplayedScrollingRowIndex != gridView2.FirstDisplayedScrollingRowIndex)
                    try { gridView1.FirstDisplayedScrollingRowIndex = gridView2.FirstDisplayedScrollingRowIndex; } catch { }
            }

            //void dispose(object sender, EventArgs e)
            //{
            //    gridView1.Disposed -= dispose;
            //    gridView2.Disposed -= dispose;
            //    gridView1.Scroll -= gridView1Scroll;
            //    gridView2.Scroll -= gridView2Scroll;
            //}

            gridView1.Scroll += gridView1Scroll;
            gridView2.Scroll += gridView2Scroll;

            //gridView1.Disposed += dispose;
            //gridView2.Disposed += dispose;
        }

        private static void SyncSelectedRowIndex(DataGridView gridView1, DataGridView gridView2)
        {
            void gridView1CurrentCellChanged(object sender, EventArgs e)
            {
                //TODO: NullCheck
                if (gridView1.CurrentCell == null)
                    gridView2.CurrentCell = null;
                else if (gridView2.CurrentCell.RowIndex != gridView1.CurrentCell.RowIndex)
                    try { gridView2.CurrentCell = gridView2.Rows[gridView1.CurrentCell.RowIndex].Cells[gridView2.CurrentCell.ColumnIndex]; } catch { }
            };

            void gridView2CurrentCellChanged(object sender, EventArgs e)
            {
                if (gridView2.CurrentCell == null)
                    gridView1.CurrentCell = null;
                else if (gridView1.CurrentCell.RowIndex != gridView2.CurrentCell.RowIndex)
                    try { gridView1.CurrentCell = gridView1.Rows[gridView2.CurrentCell.RowIndex].Cells[gridView1.CurrentCell.ColumnIndex]; } catch { }
            };

            //void dispose(object sender, EventArgs e)
            //{
            //    gridView1.Disposed -= dispose;
            //    gridView2.Disposed -= dispose;
            //    gridView1.CurrentCellChanged -= gridView1CurrentCellChanged;
            //    gridView2.CurrentCellChanged -= gridView2CurrentCellChanged;
            //}

            gridView1.CurrentCellChanged += gridView1CurrentCellChanged;
            gridView2.CurrentCellChanged += gridView2CurrentCellChanged;

            //gridView1.Disposed += dispose;
            //gridView2.Disposed += dispose;
        }

        private static void SyncRowHeight(DataGridView gridView1, DataGridView gridView2)
        {
            void GridView1RowHeightChanged(object sender, DataGridViewRowEventArgs e)
            {
                try
                {
                    var row = gridView2.Rows[e.Row.Index];
                    if (row.Height != e.Row.Height)
                        row.Height = e.Row.Height;
                }
                catch { }
            }

            void GridView2RowHeightChanged(object sender, DataGridViewRowEventArgs e)
            {
                try
                {
                    var row = gridView1.Rows[e.Row.Index];
                    if (row.Height != e.Row.Height)
                        row.Height = e.Row.Height;
                }
                catch { }
            }

            gridView1.RowHeightChanged += GridView1RowHeightChanged;
            gridView2.RowHeightChanged += GridView2RowHeightChanged;
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
