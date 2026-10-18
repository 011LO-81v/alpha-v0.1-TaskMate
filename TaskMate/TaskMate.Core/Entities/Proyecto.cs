using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Core.Entities
{
    public class Proyecto
    {
        public int IdProyecto { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public int Progreso { get; set; }
        public int? IdResponsable { get; set; }
    }
}