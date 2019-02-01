using System;
using System.Data.SqlClient;

namespace ORM.Configuration
{
    public class ConnConfiguration
    {
        private string _serverName;
        private string _databaseName;
        private string _userId;
        private string _password;

        public string GetServerName()
        {
            return _serverName;
        }

        public string GetDatabaseName()
        {
            return _databaseName;
        }

        public string GetUserId()
        {
            return _userId;
        }

        public string GetPassword()
        {
            return _password;
        }

        public ConnConfiguration(String server, String db, String user, String pass)
        {
            _serverName = server;
            _databaseName = db;
            _userId = user;
            _password = pass;
        }

        public ConnConfiguration ServerName(string serverName)
        {
            this._serverName = serverName;
            return this;
        }

        public ConnConfiguration DatabaseName(string databaseName)
        {
            this._databaseName = databaseName;
            return this;
        }

        public ConnConfiguration UserId(string userId)
        {
            this._userId = userId;
            return this;
        }

        public ConnConfiguration Password(string password)
        {
            this._password = password;
            return this;
        }

        private void Build()
        {
            _serverName = GetServerName();
            _databaseName = GetDatabaseName();
            _userId = GetUserId();
            _password = GetPassword();
        }

        public String creteConnectionString()
        {
            return "Server=" + _serverName + ";Database=" + _databaseName + ";User Id=" +
                                           _userId + ";Password=" + _password + ";MultipleActiveResultSets=true;";

        }
    }
}

