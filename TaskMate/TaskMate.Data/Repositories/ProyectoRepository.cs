using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using TaskMate.Core.Entities;

namespace TaskMate.Data.Repositories
{
    public class ProyectoRepository
    {
        public IEnumerable<Proyecto> GetAll()
        {
            using (var db = ConnectionFactory.GetConnection())
            {
                string sql = @"
                    SELECT 
                        id_proyecto AS IdProyecto,
                        nombre_proyecto AS NombreProyecto,
                        descripcion AS Descripcion,
                        fecha_inicio AS FechaInicio,
                        fecha_fin_estimada AS FechaFinEstimada,
                        estado AS Estado,
                        creado_por AS CreadoPor
                    FROM proyectos";

                return db.Query<Proyecto>(sql);
            }
        }
    }
}
