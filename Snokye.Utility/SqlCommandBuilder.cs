using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Snokye.Utility
{
    public class SqlCommandBuilder
    {
        private Dictionary<string, string> _aliasDisctionary = new Dictionary<string, string>();

        public void AddTable(string tableName, string alias = null)
        {
            if (tableName.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(tableName));

            if (alias.IsNullOrWhiteSpace())
            {
                alias = tableName;
            }


        }


        string from;
        string select;
        string orderby;
        string where;
    }
}
