using Snokye.Utility;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Snokye.VVM
{
    public class ViewModelBase : MarshalByRefObject, INotifyPropertyChanged
    {
        public Action<string, string> ValidateFialedAction;

        protected virtual bool Validate()
        {
            if (!ValidateAttribute.ValidateObject(this, out string p, out string r))
            {
                ValidateFialedAction?.Invoke(p, r);
                return false;
            }

            return true;
        }

        #region Modified

        protected bool _modified = false;

        public bool GetIsModified() => _modified;

        public void SetUnModified() => _modified = false;

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged<T>(Expression<Func<T>> expression)
        {
            if (expression.Body is MemberExpression memberExpress)
            {
                OnPropertyChanged(memberExpress.Member.Name);
            }
        }

        public virtual void OnPropertyChanged(string propertyName)
        {
            _modified = true;

            if (PropertyChanged != null && !propertyName.IsNullOrWhiteSpace())
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
