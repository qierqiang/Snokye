using Snokye.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Snokye.Controls
{
    public static class ControlHelper
    {
        //control
        public static Control FindFirstChildControl(this Control container, Func<Control, bool> filter)
        {
            foreach (Control c in container.Controls)
            {
                if (filter(c))
                    return c;

                Control result = FindFirstChildControl(c, filter);
                if (result != null)
                    return result;
            }

            return null;
        }

        public static IEnumerable<Control> FindChildControl(this Control container, Func<Control, bool> filter)
        {
            foreach (Control c in container.Controls)
            {
                if (filter(c))
                    yield return c;

                foreach (var item in FindChildControl(c, filter))
                {
                    yield return item;
                }
            }
        }

        public static Form GetParentForm(this Control source) => GetSpecificParent(source, p => p is Form) as Form;

        public static T GetSpecificTypeParent<T>(this Control source) where T : Control => GetSpecificParent(source, p => p is T) as T;

        public static Control GetSpecificParent(this Control source, Func<Control, bool> matcher)
        {
            if (source.Parent == null)
                return null;

            if (matcher(source.Parent))
                return source.Parent;

            return source.Parent.GetSpecificParent(matcher);
        }

        //errorProvider
        public static void ShowError(this ErrorProvider provider, Control ctrl, string error)
        {
            provider.SetError(ctrl, error);
            ctrl.Focus();
            EventHandler action = null;
            action = (object sender, EventArgs e) =>
            {
                provider.Clear();
                ctrl.TextChanged -= action;
            };
            ctrl.TextChanged += action;
        }

        //backGroudWorker
        public static void BackWork(this Form source, Func<object> backWork, Action<object> done)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += (object sender, DoWorkEventArgs e) => e.Result = backWork();
            bw.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) =>
            {
                if (!e.Cancelled)
                {
                    if (e.Error != null)
                    {
                        Msgbox.Error(e.Error.Message);
                        return;
                    }
                    done(e.Result);
                }
            };
            bw.RunWorkerAsync();
        }

        //dataGridView
        public static void SyncVerticalScroll(this DataGridView gridView1, DataGridView gridView2)
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

        public static void SyncSelectedRowIndex(this DataGridView gridView1, DataGridView gridView2)
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

        public static void SyncRowHeight(this DataGridView gridView1, DataGridView gridView2)
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

        public static DataGridViewColumn CreateColumn(this DataGridView gridView, Type columnType, string title, string dataPropertyName = null, string name = null, int width = 100, DataGridViewColumnSortMode sortMode = DataGridViewColumnSortMode.Programmatic, SortOrder sortOrder = SortOrder.None, bool visible = true, int colIndex = -1, bool frozen = false)
        {
            DataGridViewColumn col = (DataGridViewColumn)Activator.CreateInstance(columnType, true);
            col.HeaderText = title ?? throw new ArgumentNullException(nameof(title));
            col.DataPropertyName = dataPropertyName;
            col.Name = name;
            col.Width = width;
            col.FillWeight = width;
            col.Visible = visible;
            col.Frozen = frozen;
            if (colIndex > -1)
            {
                gridView.Columns.Insert(colIndex, col);
            }
            else
            {
                gridView.Columns.Add(col);
            }
            if (!col.DataPropertyName.IsNullOrWhiteSpace())
            {
                col.SortMode = sortMode;
                col.HeaderCell.SortGlyphDirection = sortOrder;
            }
            return col;
        }
    }
}
