using System;

namespace Snokye.VVM
{
    //[Flags]
    public enum FormCommand
    {
        New = 1,
        Edit,
        View,
        Disable,
        Delete,
        Import,
        Export,
        Sum,
        Filter,
        AdvFilter,
        RefreshData,
        CloseForm,
        Submit,
        Print,
        Check,
        UnCheck,
    }
}
