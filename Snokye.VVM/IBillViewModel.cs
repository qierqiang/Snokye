using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Snokye.VVM
{
    public interface IBillViewModel
    {
        Type GetDetailModelType();

        IBindingList GetDetails();

        ViewModelBase NewDetail();
    }
}
