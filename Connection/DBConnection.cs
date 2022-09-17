using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace EjercicioCanellaAPI.Connection
{
    public class DBConnection
    {
        private static SqlConnection ObjConnection;
        private static string error;

        public static SqlConnection GetConnection()
        {
            if (ObjConnection != null)
                return ObjConnection;

            ObjConnection = new SqlConnection
            {
                ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;User Id=suport; Password=12345; Initial Catalog=prueba_tecnica; Integrated Security=True;MultipleActiveResultSets=true"
            };

            try
            {
                ObjConnection.Open();
                return ObjConnection;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return null;
            }
        }

        public static void CloseConnection()
        {
            if (ObjConnection != null)
                ObjConnection.Close();
        }
    }
}
