using System.Collections.ObjectModel;
using TaskMate.Helpers;
using TaskMate.Models;

namespace TaskMate.ViewModels
{
    /// <summary>ViewModel de la pantalla "Notificaciones".</summary>
    public class NotificacionesViewModel : ViewModelBase
    {
        public ObservableCollection<NotificacionModel> Notificaciones { get; set; }

        public RelayCommand MarcarLeidaCommand { get; private set; }
        public RelayCommand MarcarTodasLeidasCommand { get; private set; }

        public NotificacionesViewModel()
        {
            Notificaciones = new ObservableCollection<NotificacionModel>
            {
                new NotificacionModel
                {
                    Titulo = "Nueva tarea asignada: Diseñar landing page",
                    Descripcion = "El proyecto 'Rediseño Web' requiere tus aportes de diseño iniciales.",
                    Tiempo = "Hace 5 minutos",
                    Tipo = "Info",
                    Leida = false
                },
                new NotificacionModel
                {
                    Titulo = "Tarea próxima a vencer: Revisar documentación",
                    Descripcion = "La tarea finaliza hoy a las 18:00.",
                    Tiempo = "Hace 2 horas",
                    Tipo = "Alerta",
                    Leida = false
                },
                new NotificacionModel
                {
                    Titulo = "Tarea atrasada: Actualizar API",
                    Descripcion = "Se superó la fecha límite del 15/05.",
                    Tiempo = "Hace 1 día",
                    Tipo = "Urgente",
                    Leida = true
                },
                new NotificacionModel
                {
                    Titulo = "Comentario recibido en: Diseño de dashboard",
                    Descripcion = "Dummy 2 comentó: 'Me parece correcto el flujo propuesto.'",
                    Tiempo = "Hace 2 días",
                    Tipo = "Neutral",
                    Leida = true
                },
                new NotificacionModel
                {
                    Titulo = "Proyecto actualizado: Portal Cliente",
                    Descripcion = "Se añadieron 4 nuevas tareas al backlog.",
                    Tiempo = "Hace 3 días",
                    Tipo = "Exito",
                    Leida = true
                },
            };

            MarcarLeidaCommand = new RelayCommand(param =>
            {
                var n = param as NotificacionModel;
                if (n != null) n.Leida = true;
            });

            MarcarTodasLeidasCommand = new RelayCommand(() =>
            {
                foreach (var n in Notificaciones) n.Leida = true;
            });
        }
    }
}
