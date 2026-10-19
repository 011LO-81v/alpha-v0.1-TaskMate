using TaskMate.UI.ViewModels;

namespace TaskMate.UI.Models
{
    /// <summary>Representa un proyecto de la compañía (mock data).</summary>
    public class ProyectoModel : ViewModelBase
    {
        private string _nombre;
        public string Nombre { get { return _nombre; } set { SetField(ref _nombre, value); } }

        private string _descripcion;
        public string Descripcion { get { return _descripcion; } set { SetField(ref _descripcion, value); } }

        private string _estado; // Activo | Pausado | Completado
        public string Estado { get { return _estado; } set { SetField(ref _estado, value); } }

        private string _responsable;
        public string Responsable { get { return _responsable; } set { SetField(ref _responsable, value); } }

        private int _totalTareas;
        public int TotalTareas { get { return _totalTareas; } set { SetField(ref _totalTareas, value); } }

        private double _progreso; // 0-100
        public double Progreso { get { return _progreso; } set { SetField(ref _progreso, value); } }
    }
}
