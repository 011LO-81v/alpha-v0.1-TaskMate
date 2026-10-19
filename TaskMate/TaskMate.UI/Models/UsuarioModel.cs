using TaskMate.UI.ViewModels;

namespace TaskMate.UI.Models
{
    /// <summary>Representa un miembro del equipo (mock data).</summary>
    public class UsuarioModel : ViewModelBase
    {
        private string _nombre;
        public string Nombre { get { return _nombre; } set { SetField(ref _nombre, value); } }

        private string _email;
        public string Email { get { return _email; } set { SetField(ref _email, value); } }

        private string _rol;
        public string Rol { get { return _rol; } set { SetField(ref _rol, value); } }

        private string _estado; // Activo | Inactivo
        public string Estado { get { return _estado; } set { SetField(ref _estado, value); } }

        private int _tareasAsignadas;
        public int TareasAsignadas { get { return _tareasAsignadas; } set { SetField(ref _tareasAsignadas, value); } }

        private int _proyectosActivos;
        public int ProyectosActivos { get { return _proyectosActivos; } set { SetField(ref _proyectosActivos, value); } }

        private bool _menuAbierto;
        public bool MenuAbierto { get { return _menuAbierto; } set { SetField(ref _menuAbierto, value); } }
    }
}
