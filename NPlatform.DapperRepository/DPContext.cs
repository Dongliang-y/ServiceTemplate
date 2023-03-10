//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
//		如存在本生成代码外的新需求，请在相同命名空间下创建同名分部类实现分部方法。
// </auto-generated>
//
//------------------------------------------------------------------------------
/***********************************************************
**项目名称:	                                                                  				   
**功能描述:	  的摘要说明
**作    者: 	易栋梁                                         			   
**版 本 号:	1.0                                                  			   
**创建日期： 2017-08-09 16:49
**修改历史：
************************************************************/
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;
using DapperExtensions;
using NPlatform.Infrastructure;
using NPlatform.Domains;
using System.Collections;
using System.Collections.Generic;
using NPlatform.Domains.IRepositories;
using System.Linq;
using System.Diagnostics;
using NPlatform.Infrastructure.Loger;
using System.ComponentModel;
using MySql.Data.MySqlClient;
using System.Text;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using NPlatform.Infrastructure.Config;

namespace NPlatform.Repositories
{
    /// <summary>
    /// NPlatform上下文
    /// </summary>
    public class DPContext: IDbConnection
    {
        private static readonly object LockHelper = new object();

        private string _ConnectionString = string.Empty;
        /// 得到web.config里配置项的数据库连接字符串。  
        public  string ConnectionString
        {
            get
            {
                return _ConnectionString;
            }
            set
            {
                _ConnectionString = value;
            }
        }

        private static DbProviderFactory df = null;
        /// <summary>
        /// 连接上下文
        /// </summary>
        protected IDbConnection _queryContext = null;

        /// <summary>
        /// 连接上下文
        /// </summary>
        protected IDbConnection Connection
        {
            get
            {
                if (_queryContext != null)
                {
                    if (_queryContext.State != ConnectionState.Open)
                    {
                        _queryContext.Open();
                    }
                    return _queryContext;
                }
                _queryContext = df.CreateConnection();
                _queryContext.ConnectionString = ConnectionString;
                _queryContext.Open();
                System.Diagnostics.Debug.WriteLine($"{(_queryContext as object).GetHashCode()} | TransConn 创建");
                return _queryContext;

            }
        }

        /// <summary>
        /// 超时时间
        /// </summary>
        public int ConnectionTimeout { get; set; }=180;

        /// <summary>
        /// 数据库
        /// </summary>
        public string Database
        {
            get
            {
                return Connection.Database;
            }
        }

        /// <summary>
        /// 连接状态
        /// </summary>
        public ConnectionState State {
            get
            {
                return Connection.State;
            }
        }
      
        public DPContext(IDbConnection connection)
        {
            this.ConnectionTimeout = connection.ConnectionTimeout;
            _queryContext = connection;
            _ConnectionString = connection.ConnectionString;
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }
        }
        /// <summary>  
        /// 创建连接  
        /// </summary>  
        public DPContext(string connectionString, DBProvider dbProvider,int timeOut=180)
        {
            this.ConnectionTimeout = timeOut;
            _ConnectionString = connectionString;
            DapperExtensions.DapperExtensions.DefaultMapper = typeof(DapperExt.CustomClassMapper<>);
            switch (dbProvider)
            {
                //case DBProvider.OracleClient:
                //    {
                //        //// oracle 要引入oracle 包，并注入此工厂。
                //        //DbProviderFactories.RegisterFactory(DBProvider.OracleClient.ToString(), System.Data.OracleClient.OracleClientFactory.Instance);
                //        //DapperExtensions.DapperExtensions.SqlDialect = new DapperExtensions.Sql.OracleDialect();
                //        //break;
                //    }
                case DBProvider.MySqlClient:
                    {
                        DbProviderFactories.RegisterFactory(DBProvider.MySqlClient.ToString(), new MySql.Data.MySqlClient.MySqlClientFactory());
                        DapperExtensions.DapperExtensions.SqlDialect = new DapperExtensions.Sql.MySqlDialect();
                        break;
                    }
                //case DBProvider.SQLite:
                //    {
                //        DbProviderFactories.RegisterFactory(DBProvider.SQLite.ToString(), new System.Data.SQLite.SQLiteFactory());
                //        DapperExtensions.DapperExtensions.SqlDialect = new DapperExtensions.Sql.SqliteDialect();
                //        break;
                //    }
                //default:
                //    {
                //        DbProviderFactories.RegisterFactory(DBProvider.SqlClient.ToString(), System.Data.SqlClient.SqlClientFactory.Instance);
                //        DapperExtensions.DapperExtensions.SqlDialect = new DapperExtensions.Sql.SqlServerDialect();
                //        break;
                //    }
            }
            if (df == null)
                df = DbProviderFactories.GetFactory(dbProvider.ToString());

        }
        /// <summary>
        /// 注销连接
        /// </summary>
        public void Dispose()
        {
            try
            {
                _queryContext.Close();
                _queryContext.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            try
            {
                GC.SuppressFinalize(this);
            }
            catch
            {
                // i
            }
        }

        /// <summary>
        /// 启动事务
        /// </summary>
        /// <returns></returns>
        public IDbTransaction BeginTransaction()
        {
            return Connection.BeginTransaction();
        }

        /// <summary>
        /// 类型是否为空
        /// </summary>
        /// <param name="t">t</param>
        /// <returns>bool</returns>
        private static bool IsNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }
        /// <summary>
        /// 获取类型
        /// </summary>
        /// <param name="t">类型</param>
        /// <returns>Type</returns>
        private static Type GetCoreType(Type t)
        {
            if (t != null && IsNullable(t))
            {
                if (!t.IsValueType)
                {
                    return t;
                }
                else
                {
                    return Nullable.GetUnderlyingType(t);
                }
            }
            else
            {
                return t;
            }
        }

        /// <summary>
        /// 启动事务
        /// </summary>
        /// <param name="il"></param>
        /// <returns></returns>
        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            return Connection.BeginTransaction(il);
        }
        /// <summary>
        /// 修改数据库
        /// </summary>
        /// <param name="databaseName"></param>
        public void ChangeDatabase(string databaseName)
        {
            Connection.ChangeDatabase(databaseName);
        }
        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Close()
        {
            Connection.Close();
        }

        /// <summary>
        /// 创建命令
        /// </summary>
        /// <returns></returns>
        public IDbCommand CreateCommand()
        {
            return Connection.CreateCommand();
        }
        /// <summary>
        /// 打开连接
        /// </summary>
        public void Open()
        {
            Connection.Open();
        }
    }
}
