using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using TaskMate.Core.Entities; // Entidades reales de la arquitectura
using TaskMate.Services;      // Capa de servicios
using TaskMate.UI.Helpers;

namespace TaskMate.UI.ViewModels
{
    public class ProyectosViewModel : INotifyPropertyChanged
    {
        private readonly ProyectoService _proyectoService;
        private ObservableCollection<Proyecto> _listaProyectos;

        public ObservableCollection<Proyecto> ListaProyectos
        {
            get => _listaProyectos;
            set
            {
                _listaProyectos = value;
                OnPropertyChanged(nameof(ListaProyectos));
            }
        }

        public ICommand CargarProyectosCommand { get; }

        public ProyectosViewModel()
        {
            _proyectoService = new ProyectoService();
            ListaProyectos = new ObservableCollection<Proyecto>();

            // Cargar datos reales al instanciar
            CargarProyectosReales();
        }

        private void CargarProyectosReales()
        {
            // Consultamos la base de datos MySQL a través de la capa de servicios
            var proyectos = _proyectoService.ObtenerTodosLosProyectos();

            ListaProyectos.Clear();
            foreach (var item in proyectos)
            {
                ListaProyectos.Add(item);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}