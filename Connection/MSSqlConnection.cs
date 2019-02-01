using System;
using System.Data.SqlClient;
using ORM.Configuration;

namespace ORM.Connection
{
    public class MSSqlConnection : IDisposable
    {
        private static readonly MSSqlConnection Instance = new MSSqlConnection();
        private SqlConnection Conn { get; }
        private ConnConfiguration _config;


        private MSSqlConnection()
        {
            Conn = new SqlConnection();
        }

        public SqlConnection GetSqlConnection()
        {
            return Conn;
        }

        public static MSSqlConnection GetInstance()
        {
            return Instance;
        }

        public void setConfiguration(ConnConfiguration config)
        {
            _config = config;
        }

        public void ConnectAndOpen()
        {
            Conn.ConnectionString = _config.creteConnectionString();
            Console.WriteLine(_config.creteConnectionString());
            Conn.Open();
        }

        public void Dispose()
        {
            this.Conn.Close();
            this.Conn.Dispose();
        }

        public SqlCommand execute(String command)
        {
            return new SqlCommand(command, this.GetSqlConnection());
        }

        public SqlDataReader executeReader(SqlCommand cmd)
        {
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
    }
}
