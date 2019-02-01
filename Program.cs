using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using ORM.Configuration;
using ORM.Connection;

namespace ORM
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ConnConfiguration configuration = new ConnConfiguration("localhost", "TestDB", "SA", "Cezarypazura1");
            var msSqlConnection = MSSqlConnection.GetInstance();
            msSqlConnection.setConfiguration(configuration);
            msSqlConnection.ConnectAndOpen();

            SqlCommand cmd = msSqlConnection.execute("SELECT name FROM sys.Tables");
            // SqlCommand cmd = new SqlCommand("SELECT name FROM sys.Tables", msSqlConnection.GetSqlConnection());
            // SqlDataReader reader = cmd.ExecuteReader();
            SqlDataReader reader = msSqlConnection.executeReader(cmd);
            while (reader.Read())
                Console.WriteLine(reader["name"].ToString());

            PropertyInfo[] myPropertyInfo;
            // Get the properties of 'Type' class object.
            myPropertyInfo = Type.GetType("System.Type").GetProperties();
            Console.WriteLine("Properties of System.Type are:");
            for (int i = 0; i < myPropertyInfo.Length; i++)
            {
                Console.WriteLine(myPropertyInfo[i].ToString());
            }

        }
    }
}
