using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snokye.Controls
{
    public partial class PagingControl : UserControl
    {
        //fields
        private int _totalCount;
        private int _pageCount;
        private int _currentPageFirst;
        private int _currentPageLast;
        private bool _canMovePrev;
        private bool _canMoveNext;
        
        public int CurrentPage
        {
            get => Convert.ToInt32(nCurPage.Value);
            set
            {
                if (value >= nCurPage.Minimum && value <= nCurPage.Maximum)
                {
                    nCurPage.Value = value;
                    lCurPage.Text = value.ToString();
                    Calculate();
                }
            }
        }

        public PagingControl()
        {
            InitializeComponent();
            nCurPage.ValueChanged += (object sender, EventArgs e) => CurrentPage = Convert.ToInt32(nCurPage.Value);
            bFirst.Click += (object sender, EventArgs e) => CurrentPage = 1;
            bPrev.Click += (object sender, EventArgs e) => CurrentPage--;
            bNext.Click += (object sender, EventArgs e) => CurrentPage++;
            bLast.Click += (object sender, EventArgs e) => CurrentPage = PageCount;
        }

        public void Init(int totalCount)
        {
            TotalCount = totalCount;
            PageCount = Convert.ToInt32(Math.Ceiling((double)TotalCount / (double)CountPerPage));
            CurrentPage = 1;
        }

        //private
        private int TotalCount
        {
            get => _totalCount;
            set
            {
                _totalCount = value;
                lTotalCount.Text = value.ToString();
            }
        }

        private int PageCount
        {
            get => _pageCount;
            set
            {
                _pageCount = value;
                lPageCount.Text = value.ToString();
                nCurPage.Maximum = value;
            }
        }

        private int CurrentPageFirst
        {
            get => _currentPageFirst;
            set
            {
                _currentPageFirst = value;
                lCurFirst.Text = value.ToString();
            }
        }

        private int CurrentPageLast
        {
            get => _currentPageLast;
            set
            {
                _currentPageLast = value;
                lCurLast.Text = value.ToString();
            }
        }

        private bool CanMovePrev
        {
            get => _canMovePrev;
            set
            {
                _canMovePrev = value;
                bPrev.Enabled = value;
                bFirst.Enabled = value;
            }
        }

        private bool CanMoveNext
        {
            get => _canMoveNext;
            set
            {
                _canMoveNext = value;
                bNext.Enabled = value;
                bLast.Enabled = value;
            }
        }

        private void Calculate()
        {
            PageCount = Convert.ToInt32(Math.Ceiling((double)TotalCount / (double)CountPerPage));
            CurrentPageFirst = (CurrentPage - 1) * CountPerPage + 1;
            CurrentPageLast = Math.Min((CurrentPage) * CountPerPage, TotalCount);
            CanMovePrev = CurrentPage > 1;
            CanMoveNext = PageCount + 1 > CurrentPage;
        }

        //static
        private static int _countPerPage;

        public static int CountPerPage
        {
            get => _countPerPage;
            set
            {
                if (value != 0)
                    _countPerPage = value;
            }
        }

        static PagingControl() => CountPerPage = 100;
    }
}
