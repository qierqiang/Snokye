﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace Snokye.Utility
{
    public class SqlDatabase : IDisposable
    {
        public SqlDatabase()
        {
#if DEBUG
            string cnn = "Data Source=.;Initial Catalog=SnokyeDev;Persist Security Info=True;User ID=sa;Password=123456";
            ConnectionString = cnn;
            Connection = new SqlConnection(cnn);
#else
            string cnn = ConfigurationManager.ConnectionStrings[CodeHelper.GetApplicationTitle()].ConnectionString;
            if (cnn != null)
            {
                ConnectionString = cnn ?? throw new Exception("未能找到数据库连接字符串");
                Connection = new SqlConnection(cnn);
            }
#endif
        }

        public SqlDatabase(FileInfo exeFile, string name)
        {
            string cnn = ConfigurationManager.OpenExeConfiguration(exeFile.FullName).ConnectionStrings.ConnectionStrings[name].ConnectionString;
            ConnectionString = cnn ?? throw new Exception("未能找到数据库连接字符串");
            Connection = new SqlConnection(cnn);
        }

        public SqlDatabase(string cnnString)
        {
            if (cnnString.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(cnnString));

            //从appConfig中读取
            if (cnnString.StartsWith("name=", StringComparison.CurrentCultureIgnoreCase))
            {
                string cnn = ConfigurationManager.ConnectionStrings[cnnString.Substring(5)].ConnectionString;
                ConnectionString = cnn ?? throw new Exception("未能找到数据库连接字符串");
                Connection = new SqlConnection(cnn);
            }
            else
            {
                ConnectionString = cnnString;
                Connection = new SqlConnection(ConnectionString);
            }
        }

        public string ConnectionString { get; set; }

        #region Connection

        /// <summary>与数据库的连接Connection实例</summary>
        public SqlConnection Connection { get; set; }

        /// <summary>保持连接处于打开状态</summary>
        public bool KeepConnectionOpen { get; set; }

        /// <summary>打开连接</summary>
        protected virtual void OpenConnection()
        {
            if (this.Connection == null)
                throw new Exception("Connection属性未设置!");

            if (this.Connection.State == ConnectionState.Closed)
                this.Connection.Open();
        }

        /// <summary>关闭连接</summary>
        protected virtual void CloseConnection()
        {
            if (!this.KeepConnectionOpen &&
                this.Transaction == null &&
                this.Connection.State != ConnectionState.Closed)
                this.Connection.Close();
        }

        #endregion

        #region Transaction

        /// <summary>事务</summary>
        public SqlTransaction Transaction { get; private set; }

        /// <summary>标记现在开始进行事务处理,在结束事务前所有的操作都会在事务内进行</summary>
        public void BeginTransaction()
        {
            if (this.Transaction != null)
                throw new Exception("当前数据库不支持并行事务");

            OpenConnection();
            SqlTransaction result = this.Connection.BeginTransaction();
            this.Transaction = result;
        }

        /// <summary>回滚事务</summary>
        public void RollbackTransaction()
        {
            if (this.Transaction == null)
                throw new Exception("还没有开始事务");

            this.Transaction.Rollback();
            this.Transaction = null;

            CloseConnection();
        }

        /// <summary>提交事务</summary>
        public void CommitTransaction()
        {
            if (this.Transaction == null)
                throw new Exception("还没有开始事务");

            this.Transaction.Commit();
            this.Transaction = null;

            CloseConnection();
        }

        #endregion

        #region ExecuteNonQuery

        /// <summary>执行 SQL 语句并返回受影响的行数</summary>
        public virtual int ExecuteNonQuery(string sql)
        {
            if (sql.IsNullOrWhiteSpace())
                throw new ArgumentNullException("sql");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            return ExecuteNonQuery(cmd);
        }
        /// <summary>执行 SQL 语句并返回受影响的行数</summary>
        public virtual int ExecuteNonQuery(string sql, params SqlParameter[] parms)
        {
            if (sql.IsNullOrWhiteSpace())
                throw new ArgumentNullException("sql");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            return ExecuteNonQuery(cmd, parms);
        }
        /// <summary>执行 SQL 语句并返回受影响的行数</summary>
        public virtual int ExecuteNonQuery(SqlCommand cmd)
        {
            return ExecuteNonQuery(cmd, null);
        }
        /// <summary>执行 SQL 语句并返回受影响的行数</summary>
        public virtual int ExecuteNonQuery(SqlCommand cmd, params SqlParameter[] parms)
        {
            lock (this)
            {
                if (cmd == null)
                    throw new ArgumentNullException("cmd");

                if (parms != null && parms.Length != 0)
                    foreach (IDbDataParameter param in parms)
                        cmd.Parameters.Add(param);

                OpenConnection();

                try
                {
                    cmd.Connection = this.Connection;
                    cmd.Transaction = this.Transaction;
                    return cmd.ExecuteNonQuery();
                }
                finally
                {
                    cmd.Parameters.Clear();
                    CloseConnection();
                }
            }
        }

        #endregion

        #region ExecuteScalar

        /// <summary>执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行。</summary>
        public virtual object ExecuteScalar(string sql)
        {
            if (sql.IsNullOrWhiteSpace())
                throw new ArgumentNullException("sql");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            return ExecuteScalar(cmd);
        }
        /// <summary>执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行。</summary>
        public virtual object ExecuteScalar(string sql, params SqlParameter[] parms)
        {
            if (sql.IsNullOrWhiteSpace())
                throw new ArgumentNullException("sql");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            return ExecuteScalar(cmd, parms);
        }
        /// <summary>执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行。</summary>
        public virtual object ExecuteScalar(SqlCommand cmd)
        {
            return ExecuteScalar(cmd, null);
        }
        /// <summary>执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行。</summary>
        public virtual object ExecuteScalar(SqlCommand cmd, params SqlParameter[] parms)
        {
            lock (this)
            {
                if (cmd == null)
                    throw new ArgumentNullException("cmd");

                if (parms != null && parms.Length != 0)
                    foreach (SqlParameter param in parms)
                        cmd.Parameters.Add(param);

                OpenConnection();

                try
                {
                    cmd.Connection = this.Connection;
                    cmd.Transaction = this.Transaction;
                    return cmd.ExecuteScalar();
                }
                finally
                {
                    cmd.Parameters.Clear();
                    CloseConnection();
                }
            }
        }

        #endregion

        #region ExecuteReader

        /// <summary>生成一个 DbDataReader</summary>
        public virtual IDataReader ExecuteReader(string sql)
        {
            if (sql.IsNullOrWhiteSpace())
                throw new ArgumentNullException("sql");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            return ExecuteReader(cmd);
        }
        /// <summary>生成一个 DbDataReader</summary>
        public virtual IDataReader ExecuteReader(string sql, params SqlParameter[] parms)
        {
            if (sql.IsNullOrWhiteSpace())
                throw new ArgumentNullException("sql");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            return ExecuteReader(cmd, parms);
        }
        /// <summary>生成一个 DbDataReader</summary>
        public virtual IDataReader ExecuteReader(SqlCommand cmd)
        {
            return ExecuteReader(cmd, null);
        }
        /// <summary>生成一个 DbDataReader</summary>
        public virtual SqlDataReader ExecuteReader(SqlCommand cmd, params SqlParameter[] parms)
        {
            lock (this)
            {
                if (cmd == null)
                    throw new ArgumentNullException("cmd");

                if (parms != null && parms.Length != 0)
                    foreach (SqlParameter param in parms)
                        cmd.Parameters.Add(param);

                OpenConnection();

                cmd.Connection = this.Connection;
                cmd.Transaction = this.Transaction;

                return cmd.ExecuteReader();
            }
        }

        #endregion

        #region GetDataSet

        /// <summary>执行查询，并返回查询所返回的结果集</summary>
        public virtual DataSet GetDataSet(string sql)
        {
            if (sql.IsNullOrWhiteSpace())
                throw new ArgumentNullException("sql");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            return GetDataSet(cmd);
        }
        /// <summary>执行查询，并返回查询所返回的结果集</summary>
        public virtual DataSet GetDataSet(string sql, params SqlParameter[] parms)
        {
            if (sql.IsNullOrWhiteSpace())
                throw new ArgumentNullException("sql");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            return GetDataSet(cmd, parms);
        }
        /// <summary>执行查询，并返回查询所返回的结果集</summary>
        public virtual DataSet GetDataSet(SqlCommand cmd)
        {
            return GetDataSet(cmd, null);
        }
        /// <summary>执行查询，并返回查询所返回的结果集</summary>
        public virtual DataSet GetDataSet(SqlCommand cmd, params SqlParameter[] parms)
        {
            lock (this)
            {
                if (cmd == null)
                    throw new ArgumentNullException("cmd");

                if (parms != null && parms.Length != 0)
                    foreach (SqlParameter param in parms)
                        cmd.Parameters.Add(param);

                OpenConnection();

                try
                {
                    cmd.Connection = this.Connection;
                    cmd.Transaction = this.Transaction;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;
                    DataSet result = new DataSet();
                    adapter.Fill(result);
                    return result;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    CloseConnection();
                }
            }
        }

        #endregion

        #region GetDataTable

        /// <summary>执行查询，并返回查询所返回的表</summary>
        public virtual DataTable GetDataTable(string sql)
        {
            if (sql.IsNullOrWhiteSpace())
                throw new ArgumentNullException("sql");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            return GetDataTable(cmd);
        }
        /// <summary>执行查询，并返回查询所返回的表</summary>
        public virtual DataTable GetDataTable(string sql, params SqlParameter[] parms)
        {
            if (sql.IsNullOrWhiteSpace())
                throw new ArgumentNullException("sql");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            return GetDataTable(cmd, parms);
        }
        /// <summary>执行查询，并返回查询所返回的表</summary>
        public virtual DataTable GetDataTable(SqlCommand cmd)
        {
            return GetDataTable(cmd, null);
        }
        /// <summary>执行查询，并返回查询所返回的表</summary>
        public virtual DataTable GetDataTable(SqlCommand cmd, params SqlParameter[] parms)
        {
            lock (this)
            {
                if (cmd == null)
                    throw new ArgumentNullException("cmd");

                if (parms != null && parms.Length != 0)
                    foreach (SqlParameter param in parms)
                        cmd.Parameters.Add(param);

                OpenConnection();

                try
                {
                    cmd.Connection = this.Connection;
                    cmd.Transaction = this.Transaction;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;
                    DataSet result = new DataSet();
                    adapter.Fill(result);

                    return result.Tables[0];
                }
                finally
                {
                    cmd.Parameters.Clear();
                    CloseConnection();
                }
            }
        }

        #endregion

        #region ExecuteTransaction

        /// <summary>执行数据库事务操作</summary>
        public virtual int[] ExecuteTransaction(IEnumerable<string> sqls)
        {
            SqlCommand[] cmds = new SqlCommand[sqls.Count()];

            for (int i = 0; i < cmds.Length; i++)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sqls.ElementAt(i);
                cmds[i] = cmd;
            }

            return ExecuteTransaction(cmds);
        }
        /// <summary>执行数据库事务操作</summary>
        public virtual int[] ExecuteTransaction(IEnumerable<SqlCommand> cmds)
        {
            lock (this)
            {
                if (cmds == null || cmds.Any())
                    throw new ArgumentNullException("cmds");

                OpenConnection();

                SqlTransaction tran;// = this.Connection.BeginTransaction();

                if (this.Transaction != null)
                    tran = this.Transaction;
                else
                    tran = this.Connection.BeginTransaction();

                int[] result = new int[cmds.Count()];

                try
                {
                    for (int i = 0; i < result.Length; i++)
                    {
                        SqlCommand c = cmds.ElementAt(i);
                        c.Connection = this.Connection;
                        c.Transaction = tran;
                        result[i] = c.ExecuteNonQuery();
                    }

                    if (tran != this.Transaction)
                        tran.Commit();

                    return result;
                }
                catch
                {
                    try { tran.Rollback(); }
                    catch { }
                    throw;
                }
                finally
                {
                    CloseConnection();
                }
            }
        }

        #endregion

        #region GetColumnValues

        /// <summary>执行一条语句返回结果的第一列所有的值集合,忽略其实的列</summary>
        public virtual IEnumerable<T> GetColumnValues<T>(string sql)
        {
            if (sql.IsNullOrWhiteSpace())
                throw new ArgumentNullException("sql");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            return GetColumnValues<T>(cmd);
        }
        /// <summary>执行一条语句返回结果的第一列所有的值集合,忽略其实的列</summary>
        public virtual IEnumerable<T> GetColumnValues<T>(string sql, params SqlParameter[] parms)
        {
            if (sql.IsNullOrWhiteSpace())
                throw new ArgumentNullException("sql");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            return GetColumnValues<T>(cmd, parms);
        }
        /// <summary>执行一条语句返回结果的第一列所有的值集合,忽略其实的列</summary>
        public virtual IEnumerable<T> GetColumnValues<T>(SqlCommand cmd)
        {
            return GetColumnValues<T>(cmd, null);
        }
        /// <summary>执行一条语句返回结果的第一列所有的值集合,忽略其实的列</summary>
        public virtual IEnumerable<T> GetColumnValues<T>(SqlCommand cmd, params SqlParameter[] parms)
        {
            DataTable dt = this.GetDataTable(cmd, parms);

            foreach (DataRow row in dt.Rows)
                yield return (T)row[0];
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            KeepConnectionOpen = false;
            if (Transaction != null)
            {
                try { Transaction.Rollback(); }
                catch { }
                Transaction = null;
            }
            CloseConnection();
        }

        #endregion

        public static SqlParameter[] ToParameters(params object[] keyValue)
        {
            if (keyValue == null)
            {
                throw new ArgumentNullException(nameof(keyValue));
            }
            if (Convert.ToBoolean(keyValue.Length % 2))
            {
                throw new ArgumentException("数组长度不是偶数！");
            }
            SqlParameter[] result = new SqlParameter[keyValue.Length / 2];

            for (int i = 0; i < keyValue.Length; i += 2)
            {
                string key = keyValue[i].ToString();
                object val = keyValue[i + 1];
                result[i / 2] = new SqlParameter(key, val);
            }

            return result;
        }
    }
}
