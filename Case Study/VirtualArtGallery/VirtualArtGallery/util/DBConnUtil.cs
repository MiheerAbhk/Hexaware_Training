
using System.Data.SqlClient;

namespace VirtualArtGallery.util
{
    public class DBConnUtil
    {
        private static SqlConnection connection;
        public static SqlConnection GetConnection(string propertyFile)
        {
            if (connection == null)
            {
                string connStr = DBPropertyUtil.GetPropertyString(propertyFile);
                connection = new SqlConnection(connStr);
            }
            return connection;
        }

        public static void CloseConnection()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
        }
    }
}
