using TaskMate.UI.ViewModels;

namespace TaskMate.UI.Models
{
    /// <summary>Representa una celda del calendario mensual (mock data).</summary>
    public class CalendarDayModel : ViewModelBase
    {
        private int _dia;
        public int Dia { get { return _dia; } set { SetField(ref _dia, value); } }

        private bool _delMesActual;
        public bool DelMesActual { get { return _delMesActual; } set { SetField(ref _delMesActual, value); } }

        private string _etiqueta;
        public string Etiqueta { get { return _etiqueta; } set { SetField(ref _etiqueta, value); } }

        // Colores del chip de etiqueta: Rojo | Azul
        private string _colorEtiqueta;
        public string ColorEtiqueta { get { return _colorEtiqueta; } set { SetField(ref _colorEtiqueta, value); } }
    }
}
