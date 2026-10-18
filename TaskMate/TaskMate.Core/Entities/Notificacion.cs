using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Core.Entities
{
    public class Notificacion
    {
        public int IdNotificacion { get; set; }
        public int IdUsuario { get; set; }
        public string Mensaje { get; set; }
        public bool Leido { get; set; }
        public DateTime Fecha { get; set; }
    }
}
