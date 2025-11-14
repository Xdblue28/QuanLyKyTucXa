using System.Data.SqlClient;

namespace Register

{
    public class Connect
    {
        private static string connectionString =
            @"Data Source=localhost;Initial Catalog=QuanLyKyTucXa;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
