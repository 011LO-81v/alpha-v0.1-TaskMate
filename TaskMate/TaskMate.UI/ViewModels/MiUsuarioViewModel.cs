using System.Windows;
using TaskMate.UI.Helpers;

namespace TaskMate.ViewModels
{
    /// <summary>ViewModel de la pantalla "Mi Perfil" (Mi Usuario).</summary>
    public class MiUsuarioViewModel : ViewModelBase
    {
        private string _nombreCompleto = "Dummy 1";
        public string NombreCompleto { get { return _nombreCompleto; } set { SetField(ref _nombreCompleto, value); } }

        private string _cargo = "Administrador de Sistemas";
        public string Cargo { get { return _cargo; } set { SetField(ref _cargo, value); } }

        private string _correo = "Dummy1@miempresa.com";
        public string Correo { get { return _correo; } set { SetField(ref _correo, value); } }

        private string _telefono = "+57 300 123 4567";
        public string Telefono { get { return _telefono; } set { SetField(ref _telefono, value); } }

        private string _departamento = "Desarrollo";
        public string Departamento { get { return _departamento; } set { SetField(ref _departamento, value); } }

        private int _proyectos = 3;
        public int Proyectos { get { return _proyectos; } set { SetField(ref _proyectos, value); } }

        private int _tareasActivas = 8;
        public int TareasActivas { get { return _tareasActivas; } set { SetField(ref _tareasActivas, value); } }

        private int _completadas = 24;
        public int Completadas { get { return _completadas; } set { SetField(ref _completadas, value); } }

        public RelayCommand GuardarCommand { get; private set; }

        public MiUsuarioViewModel()
        {
            GuardarCommand = new RelayCommand(GuardarCambios);
        }

        private void GuardarCambios()
        {
            // Aquí se conectaría con el servicio/API real que persiste el perfil del usuario.
            MessageBox.Show("Los cambios del perfil se guardaron correctamente.", "TaskMate",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
