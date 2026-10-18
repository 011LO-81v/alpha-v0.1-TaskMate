using System.Data;
using Dapper;
using TaskMate.Core.Entities;

namespace TaskMate.Data.Repositories
{
    public class UsuarioRepository
    {
        public Usuario GetUsuarioByCorreo(string correo)
        {
            using (IDbConnection db = ConnectionFactory.GetConnection())
            {
                // Usamos alias (AS) para que Dapper enlace automáticamente columnas con guion bajo a las propiedades PascalCase de C#
                string sql = @"
                    SELECT 
                        id_usuario AS IdUsuario, 
                        nombre AS Nombre, 
                        correo AS Correo, 
                        password_hash AS PasswordHash, 
                        rol AS Rol, 
                        telefono AS Telefono, 
                        departamento AS Departamento, 
                        estado AS Estado 
                    FROM usuarios 
                    WHERE correo = @Correo";

                return db.QueryFirstOrDefault<Usuario>(sql, new { Correo = correo });
            }
        }
    }
}
