using System.Collections.ObjectModel;
using TaskMate.UI.Helpers;
using TaskMate.UI.Models;

namespace TaskMate.UI.ViewModels
{
    /// <summary>ViewModel de la pantalla "Calendario" (vista mensual, mock data).</summary>
    public class CalendarioViewModel : ViewModelBase
    {
        private string _mesActual = "Agosto 2026";
        public string MesActual { get { return _mesActual; } set { SetField(ref _mesActual, value); } }

        private string _vistaSeleccionada = "Mes";
        public string VistaSeleccionada { get { return _vistaSeleccionada; } set { SetField(ref _vistaSeleccionada, value); } }

        public ObservableCollection<CalendarDayModel> Dias { get; set; }
        public ObservableCollection<TareaModel> TareasDelDia { get; set; }

        public RelayCommand MesAnteriorCommand { get; private set; }
        public RelayCommand MesSiguienteCommand { get; private set; }

        public CalendarioViewModel()
        {
            Dias = new ObservableCollection<CalendarDayModel>();

            // Semana 1 (termina en julio, mes anterior)
            AgregarDia(27, false); AgregarDia(28, false); AgregarDia(29, false); AgregarDia(30, false); AgregarDia(31, false);
            AgregarDia(1, true, "Plan QA", "Alta"); AgregarDia(2, true);

            // Semana 2
            AgregarDia(3, true); AgregarDia(4, true); AgregarDia(5, true, "Feedbacks", "Baja");
            AgregarDia(6, true); AgregarDia(7, true); AgregarDia(8, true); AgregarDia(9, true);

            // Semana 3
            AgregarDia(10, true); AgregarDia(11, true, "Deploy DB", "Alta"); AgregarDia(12, true);
            AgregarDia(13, true); AgregarDia(14, true); AgregarDia(15, true); AgregarDia(16, true);

            // Semana 4
            AgregarDia(17, true); AgregarDia(18, true); AgregarDia(19, true); AgregarDia(20, true);
            AgregarDia(21, true); AgregarDia(22, true); AgregarDia(23, true);

            TareasDelDia = new ObservableCollection<TareaModel>
            {
                new TareaModel { Titulo = "Migración AWS Aurora DB", Prioridad = "Urgente", Hora = "09:30 AM" },
                new TareaModel { Titulo = "Revisión de Backups locales", Prioridad = "Media", Hora = "02:00 PM" },
            };

            MesAnteriorCommand = new RelayCommand(() => MesActual = "Julio 2026");
            MesSiguienteCommand = new RelayCommand(() => MesActual = "Septiembre 2026");
        }

        private void AgregarDia(int dia, bool delMesActual, string etiqueta = null, string color = null)
        {
            Dias.Add(new CalendarDayModel { Dia = dia, DelMesActual = delMesActual, Etiqueta = etiqueta, ColorEtiqueta = color });
        }
    }
}
