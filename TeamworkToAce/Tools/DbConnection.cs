using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace TeamworkToAce.Tools
{
    public class DbConnection : IDisposable
    {
        private SqlConnection _connection;

        public ConnectionState State
        {
            get
            {
                return this._connection != null
                        ? this._connection.State
                        : ConnectionState.Closed;
            }
        }

        public DbConnection(string connectionKey = "ACERepositoryConnection")
        {
            try
            {
                this._connection = new SqlConnection();

                // These conditions have been added for unit testing

                if (ConfigurationManager.ConnectionStrings != null && ConfigurationManager.ConnectionStrings[connectionKey] != null && !String.IsNullOrWhiteSpace(ConfigurationManager.ConnectionStrings[connectionKey].ConnectionString))
                {
                    _connection.ConnectionString = ConfigurationManager.ConnectionStrings[connectionKey].ConnectionString;
                }
                else
                {
                    _connection.ConnectionString = connectionKey;
                }
                _connection.Open();
            }
            catch (Exception ex)
            {
                //Cannot connect
                ex.StackTrace.ToString();
            }
        }

        public SqlConnection Conn
        {
            get
            {
                return _connection;
            }

            set
            {
                _connection = value;
            }
        }


        public void Close()
        {
            _connection.Close();
        }


        public void Dispose()
        {
            if (this._connection != null)
            {
                this._connection.Dispose();
            }
        }
    }
}