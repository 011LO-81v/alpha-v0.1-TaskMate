using System.Collections.ObjectModel;
using System.Windows.Controls;
using TaskMate.UI.Helpers;
using TaskMate.UI.Views;

namespace TaskMate.ViewModels
{
    /// <summary>
    /// ViewModel principal de la ventana (Shell). Controla la navegación entre
    /// las distintas vistas del sistema (Sidebar + Header) y expone comandos
    /// que reemplazan dinámicamente el contenido central (CurrentView).
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { SetField(ref _currentView, value); }
        }

        private string _selectedMenu;
        /// <summary>Clave del ítem de menú activo, usada para resaltar el botón del sidebar.</summary>
        public string SelectedMenu
        {
            get { return _selectedMenu; }
            set { SetField(ref _selectedMenu, value); }
        }

        // ---------- Encabezado (empresa / tenant) ----------
        public string NombreEmpresa { get { return "Mi Empresa"; } }
        public string NombreTenant { get { return "(Tenant 001)"; } }

        // ---------- Sección "Mi equipo" del sidebar ----------
        private bool _isTeamExpanded = true;
        public bool IsTeamExpanded
        {
            get { return _isTeamExpanded; }
            set { SetField(ref _isTeamExpanded, value); }
        }

        private bool _isProjectsExpanded = true;
        public bool IsProjectsExpanded
        {
            get { return _isProjectsExpanded; }
            set { SetField(ref _isProjectsExpanded, value); }
        }

        public ObservableCollection<string> MiEquipoResumen { get; set; }

        // ---------- Notificaciones sin leer (para el badge del header) ----------
        private int _notificacionesSinLeer = 2;
        public int NotificacionesSinLeer
        {
            get { return _notificacionesSinLeer; }
            set { SetField(ref _notificacionesSinLeer, value); OnPropertyChanged("HayNotificacionesSinLeer"); }
        }

        public bool HayNotificacionesSinLeer { get { return _notificacionesSinLeer > 0; } }

        // ---------- Comandos ----------
        public RelayCommand NavigateCommand { get; private set; }
        public RelayCommand ToggleTeamCommand { get; private set; }
        public RelayCommand ToggleProjectsCommand { get; private set; }

        public MainWindowViewModel()
        {
            MiEquipoResumen = new ObservableCollection<string> { "Dummy 1", "Dummy 2", "Dummy 3" };

            NavigateCommand = new RelayCommand(param => Navigate(param as string));
            ToggleTeamCommand = new RelayCommand(() => IsTeamExpanded = !IsTeamExpanded);
            ToggleProjectsCommand = new RelayCommand(() => IsProjectsExpanded = !IsProjectsExpanded);

            // Vista inicial: Mi Usuario (igual que la primera captura del prototipo)
            Navigate("MiUsuario");
        }

        private void Navigate(string destino)
        {
            if (string.IsNullOrEmpty(destino)) return;

            SelectedMenu = destino;

            switch (destino)
            {
                case "MiUsuario":
                    CurrentView = new MiUsuarioView();
                    break;
                case "AnadirTarea":
                    CurrentView = new AnadirTareaView();
                    break;
                case "Buscador":
                    CurrentView = new BuscadorView();
                    break;
                case "BandejaEntrada":
                    CurrentView = new BandejaEntradaView();
                    break;
                case "Calendario":
                    CurrentView = new CalendarioView();
                    break;
                case "Filtro":
                    CurrentView = new FiltroView();
                    break;
                case "Reportes":
                    CurrentView = new ReportesView();
                    break;
                case "MisProyectos":
                    CurrentView = new ProyectosView();
                    break;
                case "MiEquipo":
                    CurrentView = new EquipoView();
                    break;
                case "Notificaciones":
                    CurrentView = new NotificacionesView();
                    NotificacionesSinLeer = 0;
                    break;
                case "Ajustes":
                    CurrentView = new AjustesView();
                    break;
                default:
                    CurrentView = new MiUsuarioView();
                    break;
            }
        }
    }
}
