using System.Windows;
using TaskMate.UI.Helpers;

namespace TaskMate.ViewModels
{
    /// <summary>ViewModel de la pantalla "Bandeja de entrada" (estado vacío).</summary>
    public class BandejaEntradaViewModel : ViewModelBase
    {
        public string Mensaje { get { return "Bienvenido a tu bandeja de entrada, no tienes tareas\npendientes por el momento"; } }

        public RelayCommand CrearTareaCommand { get; private set; }

        public BandejaEntradaViewModel()
        {
            CrearTareaCommand = new RelayCommand(() =>
                MessageBox.Show("Usa el menú 'Añadir tarea' del sidebar para crear una nueva tarea.", "TaskMate",
                    MessageBoxButton.OK, MessageBoxImage.Information));
        }
    }
}
