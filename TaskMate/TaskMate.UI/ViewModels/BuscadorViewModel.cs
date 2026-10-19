using System.Collections.ObjectModel;
using TaskMate.UI.Helpers;
using TaskMate.UI.Models;

namespace TaskMate.ViewModels
{
    /// <summary>ViewModel de la pantalla "Buscador" (búsqueda global).</summary>
    public class BuscadorViewModel : ViewModelBase
    {
        private string _textoBusqueda;
        public string TextoBusqueda { get { return _textoBusqueda; } set { SetField(ref _textoBusqueda, value); } }

        private string _pestanaActiva = "Todas";
        public string PestanaActiva { get { return _pestanaActiva; } set { SetField(ref _pestanaActiva, value); } }

        public ObservableCollection<TareaModel> Tareas { get; set; }
        public ObservableCollection<ProyectoModel> Proyectos { get; set; }

        public ObservableCollection<string> OpcionesOrden { get; set; }
        public ObservableCollection<string> OpcionesFecha { get; set; }

        private string _ordenSeleccionado = "Relevancia";
        public string OrdenSeleccionado { get { return _ordenSeleccionado; } set { SetField(ref _ordenSeleccionado, value); } }

        private string _fechaSeleccionada = "Últimos 30 días";
        public string FechaSeleccionada { get { return _fechaSeleccionada; } set { SetField(ref _fechaSeleccionada, value); } }

        public RelayCommand SeleccionarPestanaCommand { get; private set; }

        public BuscadorViewModel()
        {
            Tareas = new ObservableCollection<TareaModel>
            {
                new TareaModel { Titulo = "Configurar redirecciones DNS HTTPS", Proyecto = "Proyecto: Rediseño Web Corporativa", Prioridad = "Alta" },
                new TareaModel { Titulo = "Crear plantillas HTML para correos transaccionales", Proyecto = "Proyecto: Rediseño Web Corporativa", Prioridad = "Media" },
            };

            Proyectos = new ObservableCollection<ProyectoModel>
            {
                new ProyectoModel { Nombre = "Rediseño de Web Corporativa", Descripcion = "8 de 18 tareas completadas", Progreso = 75 },
            };

            OpcionesOrden = new ObservableCollection<string> { "Relevancia", "Más reciente", "Más antiguo" };
            OpcionesFecha = new ObservableCollection<string> { "Últimos 7 días", "Últimos 30 días", "Todo el tiempo" };

            SeleccionarPestanaCommand = new RelayCommand(param => PestanaActiva = param as string);
        }
    }
}
