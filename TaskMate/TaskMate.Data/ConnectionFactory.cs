using System.Data;
using MySql.Data.MySqlClient;

namespace TaskMate.Data
{
    public static class ConnectionFactory
    {
        // Cambia Uid (usuario) y Pwd (contraseña) si tu servidor local los requiere.
        private static readonly string connectionString = "Server=localhost;Database=taskmate_db;Uid=root;Pwd=awuapanela;";

        public static IDbConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
