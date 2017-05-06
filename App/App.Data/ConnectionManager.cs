using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public class ConnectionManager
    {
        private static SqlConnection conn = new SqlConnection();
        public static string GetConnectionString()
        {
            return  ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public static SqlConnection Connection()
        {
            conn.ConnectionString = GetConnectionString();
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            return conn;
        }

        public static void Close()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
    }
}
