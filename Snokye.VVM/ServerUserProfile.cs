using Snokye.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Snokye.VVM
{
    public class ServerUserProfile
    {
        private Guid _userGuid;
        private bool _useCache;
        private SqlDatabase _database;
        private DataTable _cache;

        public bool UserCache
        {
            get => _useCache;
            set
            {
                if (value != _useCache)
                {
                    _useCache = value;
                    if (!value)
                    {
                        _cache = null;
                    }
                }
            }
        }

        public string this[string category, string key, string defaultValue]
        {
            get => GetValue(category, key, defaultValue);
            set => SetValue(category, key, defaultValue);
        }

        public ServerUserProfile(Guid userGuid)
        {
            _userGuid = userGuid;
            _useCache = true;
            _database = new SqlDatabase();
        }

        public string GetValue(string category, string key, string defaultValue)
        {
            if (UserCache)
            {
                if (_cache == null)
                    _cache = _database.GetDataTable("SELECT * FROM [ProfileSet] WHERE [UserGuid]=@p0", new SqlParameter("@p0", _userGuid));

                _cache.DefaultView.RowFilter = "[Category]='{0}' AND [Key]='{1}'".FormatWith(category, key);

                using (DataTable table = _cache.DefaultView.ToTable())
                {
                    if (table.Rows.Count == 0)
                        return defaultValue;

                    object value = table.Rows[0]["Value"];

                    if (value.IsNullOrDbNull())
                        return defaultValue;

                    return value.ToString();
                }
            }
            else
            {
                string sql = "SELECT TOP 1 [Value] FROM [ProfileSet] WHERE [Category]=@p0 AND [Key]=@p1 AND [UserGuid]=@p2";
                object value = _database.ExecuteScalar(sql, new SqlParameter("@p0", category), new SqlParameter("@p1", key), new SqlParameter("@p2", _userGuid));

                if (value.IsNullOrDbNull())
                    return defaultValue;

                return value.ToString();
            }
        }

        public void SetValue(string category, string key, string value)
        {
            value = value.IsNullOrDbNull() ? string.Empty : value;

            if (UserCache && _cache != null)
            {
                foreach (DataRow r in _cache.Rows)
                {
                    if (r["Category"].TryToString("").Equals(category, StringComparison.CurrentCultureIgnoreCase) &&
                        r["Key"].TryToString("").Equals(key, StringComparison.CurrentCultureIgnoreCase))
                    {
                        r["Value"] = value;
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("IF EXSIST(SELECT 1 FROM [ProfileSet] WHERE [Category]=@p0 AND [Key]=@p1 AND [UserGuid]=@p3)");
            sb.AppendLine("BEGIN");
            sb.AppendLine("    UPDATE [ProfileSet] SET [Value]=@p2 WHERE [Category]=@p0 AND [Key]=@p1 AND [UserGuid]=@p3)");
            sb.AppendLine("END");
            sb.AppendLine("ELSE");
            sb.AppendLine("BEGIN");
            sb.AppendLine("    INSERT INTO [ProfileSet] ([Category], [Key], [Value], [UserGuid]) VALUES (@p0, @p1, @p2, @p3)");
            sb.AppendLine("END");

            _database.ExecuteNonQuery(sb.ToJson(), SqlDatabase.ToParameters("@p0", category, "@p1", key, "@p2", value, "@p3", _userGuid));
        }
    }
}
