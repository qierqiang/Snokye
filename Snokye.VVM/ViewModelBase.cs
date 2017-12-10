using Snokye.Utility;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Snokye.VVM
{
    public class ViewModelBase : MarshalByRefObject, INotifyPropertyChanged
    {
        protected bool _modified = false;

        public bool GetIsModified() => _modified;

        public void SetUnModified() => _modified = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            _modified = true;

            if (PropertyChanged != null && !propertyName.IsNullOrWhiteSpace())
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public virtual void OnPropertyChanged<T>(Expression<Func<T>> expression)
        {
            if (expression.Body is MemberExpression memberExpress)
            {
                OnPropertyChanged(memberExpress.Member.Name);
            }
        }
    }
}
