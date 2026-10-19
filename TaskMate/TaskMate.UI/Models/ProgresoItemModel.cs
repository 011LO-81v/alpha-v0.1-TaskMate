using TaskMate.UI.ViewModels;

namespace TaskMate.UI.Models
{
    /// <summary>Representa una fila con nombre + barra de progreso + color propio (mock data).</summary>
    public class ProgresoItemModel : ViewModelBase
    {
        private string _nombre;
        public string Nombre { get { return _nombre; } set { SetField(ref _nombre, value); } }

        private double _porcentaje;
        public double Porcentaje { get { return _porcentaje; } set { SetField(ref _porcentaje, value); } }

        private string _colorHex;
        public string ColorHex { get { return _colorHex; } set { SetField(ref _colorHex, value); } }
    }
}
