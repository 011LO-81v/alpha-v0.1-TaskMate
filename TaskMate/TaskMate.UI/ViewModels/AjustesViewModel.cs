using System.Collections.ObjectModel;
using System.Windows;
using TaskMate.UI.Helpers;

namespace TaskMate.ViewModels
{
    /// <summary>
    /// ViewModel de la pantalla "Ajustes".
    /// NOTA: no se incluyó una captura de diseño específica para esta pantalla en el
    /// prototipo entregado (la imagen rotulada como "pestaña ajustes" correspondía en
    /// realidad a "Notificaciones"). Esta vista se construyó siguiendo el mismo lenguaje
    /// visual del resto de la aplicación como placeholder funcional.
    /// </summary>
    public class AjustesViewModel : ViewModelBase
    {
        private bool _notifTareaAsignada = true;
        public bool NotifTareaAsignada { get { return _notifTareaAsignada; } set { SetField(ref _notifTareaAsignada, value); } }

        private bool _notifTareaVencer = true;
        public bool NotifTareaVencer { get { return _notifTareaVencer; } set { SetField(ref _notifTareaVencer, value); } }

        private bool _notifComentarios = false;
        public bool NotifComentarios { get { return _notifComentarios; } set { SetField(ref _notifComentarios, value); } }

        private bool _notifResumenSemanal = true;
        public bool NotifResumenSemanal { get { return _notifResumenSemanal; } set { SetField(ref _notifResumenSemanal, value); } }

        private string _temaSeleccionado = "Claro";
        public string TemaSeleccionado { get { return _temaSeleccionado; } set { SetField(ref _temaSeleccionado, value); } }

        public ObservableCollection<string> Temas { get; set; }

        private string _idiomaSeleccionado = "Español";
        public string IdiomaSeleccionado { get { return _idiomaSeleccionado; } set { SetField(ref _idiomaSeleccionado, value); } }

        public ObservableCollection<string> Idiomas { get; set; }

        private string _passwordActual;
        public string PasswordActual { get { return _passwordActual; } set { SetField(ref _passwordActual, value); } }

        private string _passwordNueva;
        public string PasswordNueva { get { return _passwordNueva; } set { SetField(ref _passwordNueva, value); } }

        public RelayCommand GuardarCommand { get; private set; }
        public RelayCommand CambiarPasswordCommand { get; private set; }

        public AjustesViewModel()
        {
            Temas = new ObservableCollection<string> { "Claro", "Oscuro", "Automático (sistema)" };
            Idiomas = new ObservableCollection<string> { "Español", "Inglés" };

            GuardarCommand = new RelayCommand(() =>
                MessageBox.Show("Preferencias guardadas correctamente.", "TaskMate",
                    MessageBoxButton.OK, MessageBoxImage.Information));

            CambiarPasswordCommand = new RelayCommand(() =>
            {
                MessageBox.Show("Se ha actualizado tu contraseña.", "TaskMate",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                PasswordActual = string.Empty;
                PasswordNueva = string.Empty;
            });
        }
    }
}
