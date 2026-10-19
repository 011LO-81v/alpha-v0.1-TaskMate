using System.Collections.ObjectModel;
using System.Windows;
using TaskMate.UI.Helpers;

namespace TaskMate.ViewModels
{
    /// <summary>ViewModel de la pantalla "Nueva Tarea".</summary>
    public class AnadirTareaViewModel : ViewModelBase
    {
        private string _titulo;
        public string Titulo { get { return _titulo; } set { SetField(ref _titulo, value); } }

        private string _descripcion;
        public string Descripcion { get { return _descripcion; } set { SetField(ref _descripcion, value); } }

        private string _proyectoSeleccionado;
        public string ProyectoSeleccionado { get { return _proyectoSeleccionado; } set { SetField(ref _proyectoSeleccionado, value); } }

        private string _responsableSeleccionado;
        public string ResponsableSeleccionado { get { return _responsableSeleccionado; } set { SetField(ref _responsableSeleccionado, value); } }

        private string _etiquetas;
        public string Etiquetas { get { return _etiquetas; } set { SetField(ref _etiquetas, value); } }

        private string _prioridadSeleccionada = "Media";
        public string PrioridadSeleccionada { get { return _prioridadSeleccionada; } set { SetField(ref _prioridadSeleccionada, value); } }

        private string _estadoSeleccionado = "Pendiente";
        public string EstadoSeleccionado { get { return _estadoSeleccionado; } set { SetField(ref _estadoSeleccionado, value); } }

        private string _fechaInicio;
        public string FechaInicio { get { return _fechaInicio; } set { SetField(ref _fechaInicio, value); } }

        private string _fechaLimite;
        public string FechaLimite { get { return _fechaLimite; } set { SetField(ref _fechaLimite, value); } }

        private string _subtareas;
        public string Subtareas { get { return _subtareas; } set { SetField(ref _subtareas, value); } }

        private string _comentarios;
        public string Comentarios { get { return _comentarios; } set { SetField(ref _comentarios, value); } }

        public ObservableCollection<string> Proyectos { get; set; }
        public ObservableCollection<string> Responsables { get; set; }
        public ObservableCollection<string> Prioridades { get; set; }
        public ObservableCollection<string> Estados { get; set; }

        public RelayCommand GuardarCommand { get; private set; }
        public RelayCommand CancelarCommand { get; private set; }

        public AnadirTareaViewModel()
        {
            Proyectos = new ObservableCollection<string> { "Rediseño de Web Corporativa", "Migración Core Database", "Onboarding de Nuevos Empleados" };
            Responsables = new ObservableCollection<string> { "Sin asignar...", "Dummy 1", "Dummy 2", "Dummy 3" };
            Prioridades = new ObservableCollection<string> { "Baja", "Media", "Alta", "Urgente" };
            Estados = new ObservableCollection<string> { "Pendiente", "En progreso", "En revisión", "Completada" };

            GuardarCommand = new RelayCommand(GuardarTarea);
            CancelarCommand = new RelayCommand(LimpiarFormulario);
        }

        private void GuardarTarea()
        {
            if (string.IsNullOrWhiteSpace(Titulo))
            {
                MessageBox.Show("Por favor escribe un título para la tarea.", "TaskMate",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBox.Show("Tarea '" + Titulo + "' guardada correctamente.", "TaskMate",
                MessageBoxButton.OK, MessageBoxImage.Information);
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            Titulo = string.Empty;
            Descripcion = string.Empty;
            Etiquetas = string.Empty;
            FechaInicio = string.Empty;
            FechaLimite = string.Empty;
            Subtareas = string.Empty;
            Comentarios = string.Empty;
            ProyectoSeleccionado = null;
            ResponsableSeleccionado = "Sin asignar...";
            PrioridadSeleccionada = "Media";
            EstadoSeleccionado = "Pendiente";
        }
    }
}
