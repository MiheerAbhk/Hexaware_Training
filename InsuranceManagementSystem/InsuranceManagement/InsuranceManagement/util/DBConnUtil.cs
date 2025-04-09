using System;
using System.Data.SqlClient;

namespace InsuranceManagementSystem.util
{
    public class DBConnUtil
    {
        public static SqlConnection GetConnection(string propertyFileName)
        {
            string connString = DBPropertyUtil.GetConnectionString(propertyFileName);
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }
    }
}
