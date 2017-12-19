using Snokye.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snokye.VVM
{
    public struct FilterDefinition
    {
        public Type FilterControlType { get; set; }

        public string DataPropertyName { get; set; }

        public string Title { get; set; }

        public string FilterOperator { get; set; }

        public FilterDefinition(Type filterControlType, string dataPropertyName, string title, string filterOperator = null)
        {
            if (filterControlType == null)
                throw new ArgumentNullException(nameof(filterControlType));
            if (!filterControlType.Is(typeof(FilterControlBase)))
                throw new Exception(filterControlType.ToString() + "不是有效的FilterControlBase");
            if (CodeHelper.IsNullOrWhiteSpace(dataPropertyName))
                throw new ArgumentException("message", nameof(dataPropertyName));
            if (CodeHelper.IsNullOrWhiteSpace(title))
                throw new ArgumentException("message", nameof(title));

            FilterControlType = filterControlType;
            DataPropertyName = dataPropertyName;
            Title = title;
            FilterOperator = filterOperator;
        }
    }
}
