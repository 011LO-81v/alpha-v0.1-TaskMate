using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMate.Core.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string PasswordHash { get; set; }
        public string Rol { get; set; }
        public string Telefono { get; set; }
        public string Departamento { get; set; }
        public string Estado { get; set; }
    }
}
