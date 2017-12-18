using System;

namespace Snokye.VVM
{

    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class AutoGenControlAttribute : Attribute
    {
        public Type EditorType { get; set; }

        public string DisplayName { get; set; }

        public bool ReadOnlyWhenCreate { get; set; }

        public bool ReadOnlyWhenModify { get; set; }

        public bool Enabled { get; set; }

        public bool BeginNewRow { get; set; }

        public string GroupName { get; set; }

        public AutoGenControlAttribute()
        {
            Enabled = true;
        }
    }
}
