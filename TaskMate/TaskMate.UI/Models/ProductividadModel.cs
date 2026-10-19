using TaskMate.UI.ViewModels;

namespace TaskMate.UI.Models
{
    /// <summary>Representa la fila de "Productividad por usuario" en Reportes (mock data).</summary>
    public class ProductividadModel : ViewModelBase
    {
        private string _nombre;
        public string Nombre { get { return _nombre; } set { SetField(ref _nombre, value); } }

        private int _horas;
        public int Horas { get { return _horas; } set { SetField(ref _horas, value); } }
    }
}
