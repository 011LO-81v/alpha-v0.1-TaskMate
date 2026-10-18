using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Core.Entities
{
    public class Tarea
    {
        public int IdTarea { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Prioridad { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaLimite { get; set; }
        public int? IdProyecto { get; set; }
        public int? IdResponsable { get; set; }
    }
}
