using System.Collections.ObjectModel;
using TaskMate.UI.Helpers;
using TaskMate.UI.Models;

namespace TaskMate.ViewModels
{
    /// <summary>ViewModel de la pantalla "Reportes" (métricas, productividad y progreso).</summary>
    public class ReportesViewModel : ViewModelBase
    {
        // ---------- Tarjetas resumen ----------
        private int _tareasCompletadas = 48;
        public int TareasCompletadas { get { return _tareasCompletadas; } set { SetField(ref _tareasCompletadas, value); } }

        public string DeltaCompletadas { get { return "+12%"; } }

        private int _tareasPendientes = 15;
        public int TareasPendientes { get { return _tareasPendientes; } set { SetField(ref _tareasPendientes, value); } }

        private int _tareasAtrasadas = 3;
        public int TareasAtrasadas { get { return _tareasAtrasadas; } set { SetField(ref _tareasAtrasadas, value); } }

        // ---------- Productividad por usuario ----------
        public ObservableCollection<ProductividadModel> ProductividadPorUsuario { get; set; }

        // ---------- Tareas por estado (donut) ----------
        public int TotalTareasEstado { get { return 66; } }
        public int PctCompletado { get { return 60; } }
        public int PctEnProgreso { get { return 25; } }
        public int PctAtrasado { get { return 15; } }

        // ---------- Progreso de proyectos ----------
        public ObservableCollection<ProgresoItemModel> ProgresoProyectos { get; set; }

        public RelayCommand ExportarCommand { get; private set; }

        public ReportesViewModel()
        {
            ProductividadPorUsuario = new ObservableCollection<ProductividadModel>
            {
                new ProductividadModel { Nombre = "Dummy 1", Horas = 85 },
                new ProductividadModel { Nombre = "Dummy 2", Horas = 60 },
                new ProductividadModel { Nombre = "Dummy 3", Horas = 95 },
                new ProductividadModel { Nombre = "Juan G.", Horas = 40 },
            };

            ProgresoProyectos = new ObservableCollection<ProgresoItemModel>
            {
                new ProgresoItemModel { Nombre = "Portal de Clientes", Porcentaje = 75, ColorHex = "#3B82F6" },
                new ProgresoItemModel { Nombre = "API Integración", Porcentaje = 40, ColorHex = "#F59E0B" },
                new ProgresoItemModel { Nombre = "Rediseño Web", Porcentaje = 90, ColorHex = "#22C55E" },
            };

            ExportarCommand = new RelayCommand(() => { /* Punto de extensión: exportar reporte a PDF/Excel */ });
        }
    }
}
