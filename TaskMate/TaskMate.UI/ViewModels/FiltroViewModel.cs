using System.Collections.ObjectModel;
using TaskMate.UI.Helpers;
using TaskMate.UI.Models;

namespace TaskMate.ViewModels
{
    /// <summary>ViewModel de la pantalla "Filtros" (búsqueda avanzada / exportación).</summary>
    public class FiltroViewModel : ViewModelBase
    {
        // ---------- Selección de chips ----------
        private string _estadoSeleccionado;
        public string EstadoSeleccionado { get { return _estadoSeleccionado; } set { SetField(ref _estadoSeleccionado, value); } }

        private string _prioridadSeleccionada = "Baja";
        public string PrioridadSeleccionada { get { return _prioridadSeleccionada; } set { SetField(ref _prioridadSeleccionada, value); } }

        private string _proyectoSeleccionado;
        public string ProyectoSeleccionado { get { return _proyectoSeleccionado; } set { SetField(ref _proyectoSeleccionado, value); } }

        private string _responsableSeleccionado = "Carlos Mendoza";
        public string ResponsableSeleccionado { get { return _responsableSeleccionado; } set { SetField(ref _responsableSeleccionado, value); } }

        public ObservableCollection<string> Proyectos { get; set; }
        public ObservableCollection<string> Responsables { get; set; }
        public ObservableCollection<TareaModel> ResultadosFiltrados { get; set; }

        public int TotalResultados { get { return ResultadosFiltrados.Count; } }

        public RelayCommand SeleccionarEstadoCommand { get; private set; }
        public RelayCommand SeleccionarPrioridadCommand { get; private set; }
        public RelayCommand LimpiarFiltrosCommand { get; private set; }
        public RelayCommand AplicarFiltrosCommand { get; private set; }

        public FiltroViewModel()
        {
            Proyectos = new ObservableCollection<string> { "Rediseño de Web Corporativa", "Migración Core Database", "Onboarding de Nuevos Empleados" };
            Responsables = new ObservableCollection<string> { "Carlos Mendoza", "Dummy 1", "Dummy 2", "Dummy 3" };

            ResultadosFiltrados = new ObservableCollection<TareaModel>
            {
                new TareaModel { Titulo = "Revisión de queries de SQL de base de datos", Responsable = "Carlos Mendoza", FechaLimite = "15/08/2026", Prioridad = "Alta" },
                new TareaModel { Titulo = "Configurar CDN para hosting de assets estáticos", Responsable = "Carlos Mendoza", FechaLimite = "18/08/2026", Prioridad = "Media" },
                new TareaModel { Titulo = "Documentación de APIs internas de ERP", Responsable = "Carlos Mendoza", FechaLimite = "22/08/2026", Prioridad = "Baja" },
            };

            SeleccionarEstadoCommand = new RelayCommand(param => EstadoSeleccionado = param as string);
            SeleccionarPrioridadCommand = new RelayCommand(param => PrioridadSeleccionada = param as string);
            LimpiarFiltrosCommand = new RelayCommand(LimpiarFiltros);
            AplicarFiltrosCommand = new RelayCommand(() => OnPropertyChanged("TotalResultados"));
        }

        private void LimpiarFiltros()
        {
            EstadoSeleccionado = null;
            PrioridadSeleccionada = null;
            ProyectoSeleccionado = null;
            ResponsableSeleccionado = null;
        }
    }
}
