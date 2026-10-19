using System.Collections.ObjectModel;
using System.Windows;
using TaskMate.UI.Helpers;
using TaskMate.UI.Models;

namespace TaskMate.ViewModels
{
    /// <summary>ViewModel de la pantalla "Mi Equipo" (miembros de la organización).</summary>
    public class EquipoViewModel : ViewModelBase
    {
        public ObservableCollection<UsuarioModel> Miembros { get; set; }

        public RelayCommand ToggleMenuCommand { get; private set; }
        public RelayCommand VerPerfilCommand { get; private set; }
        public RelayCommand VerTareasCommand { get; private set; }
        public RelayCommand EditarCommand { get; private set; }
        public RelayCommand DesactivarCommand { get; private set; }
        public RelayCommand AgregarMiembroCommand { get; private set; }

        public EquipoViewModel()
        {
            Miembros = new ObservableCollection<UsuarioModel>
            {
                new UsuarioModel { Nombre = "Dummy 1", Email = "Dummy1@miempresa.com", Rol = "Administrador", Estado = "Activo", TareasAsignadas = 8, ProyectosActivos = 3 },
                new UsuarioModel { Nombre = "Dummy 2", Email = "dummy2@miempresa.com", Rol = "Desarrollador Backend", Estado = "Activo", TareasAsignadas = 12, ProyectosActivos = 2 },
                new UsuarioModel { Nombre = "Dummy 3", Email = "dummy3@miempresa.com", Rol = "Diseñadora UX/UI", Estado = "Activo", TareasAsignadas = 5, ProyectosActivos = 1 },
            };

            ToggleMenuCommand = new RelayCommand(param =>
            {
                var target = param as UsuarioModel;
                if (target == null) return;
                bool abrir = !target.MenuAbierto;
                foreach (var m in Miembros) m.MenuAbierto = false;
                target.MenuAbierto = abrir;
            });

            VerPerfilCommand = new RelayCommand(param => CerrarYAvisar(param, "Ver perfil de"));
            VerTareasCommand = new RelayCommand(param => CerrarYAvisar(param, "Ver tareas de"));
            EditarCommand = new RelayCommand(param => CerrarYAvisar(param, "Editar a"));
            DesactivarCommand = new RelayCommand(param => CerrarYAvisar(param, "Desactivar a"));

            AgregarMiembroCommand = new RelayCommand(() =>
                MessageBox.Show("Aquí se abriría el formulario para invitar a un nuevo miembro.", "TaskMate",
                    MessageBoxButton.OK, MessageBoxImage.Information));
        }

        private void CerrarYAvisar(object param, string accion)
        {
            var target = param as UsuarioModel;
            if (target == null) return;
            target.MenuAbierto = false;
            MessageBox.Show(accion + " " + target.Nombre, "TaskMate", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
