using TaskMate.UI.ViewModels;

namespace TaskMate.UI.Models
{
    /// <summary>Representa una notificación del sistema (mock data).</summary>
    public class NotificacionModel : ViewModelBase
    {
        private string _titulo;
        public string Titulo { get { return _titulo; } set { SetField(ref _titulo, value); } }

        private string _descripcion;
        public string Descripcion { get { return _descripcion; } set { SetField(ref _descripcion, value); } }

        private string _tiempo;
        public string Tiempo { get { return _tiempo; } set { SetField(ref _tiempo, value); } }

        // Color del punto indicador: Info(azul) | Alerta(naranja) | Urgente(rojo) | Neutral(gris) | Exito(verde)
        private string _tipo;
        public string Tipo { get { return _tipo; } set { SetField(ref _tipo, value); } }

        private bool _leida;
        public bool Leida { get { return _leida; } set { SetField(ref _leida, value); OnPropertyChanged("EsNoLeida"); } }

        public bool EsNoLeida { get { return !_leida; } }
    }
}
