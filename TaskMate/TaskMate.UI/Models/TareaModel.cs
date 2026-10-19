using TaskMate.UI.ViewModels;

namespace TaskMate.UI.Models
{
    /// <summary>Representa una tarea dentro de un proyecto (mock data).</summary>
    public class TareaModel : ViewModelBase
    {
        private string _titulo;
        public string Titulo { get { return _titulo; } set { SetField(ref _titulo, value); } }

        private string _descripcion;
        public string Descripcion { get { return _descripcion; } set { SetField(ref _descripcion, value); } }

        private string _proyecto;
        public string Proyecto { get { return _proyecto; } set { SetField(ref _proyecto, value); } }

        private string _prioridad; // Baja | Media | Alta | Urgente
        public string Prioridad { get { return _prioridad; } set { SetField(ref _prioridad, value); } }

        private string _estado; // Pendiente | En progreso | En revisión | Completada
        public string Estado { get { return _estado; } set { SetField(ref _estado, value); } }

        private string _responsable;
        public string Responsable { get { return _responsable; } set { SetField(ref _responsable, value); } }

        private string _fechaLimite;
        public string FechaLimite { get { return _fechaLimite; } set { SetField(ref _fechaLimite, value); } }

        private string _hora;
        public string Hora { get { return _hora; } set { SetField(ref _hora, value); } }
    }
}
