using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace TaskMate.UI.Helpers
{
    /// <summary>
    /// Convierte el estado de un proyecto ("Activo", "Pausado", "Completado") en el
    /// color de RELLENO de su barra de progreso (usado en "Mis Proyectos").
    /// </summary>
    public class EstadoToProgressColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string estado = value as string ?? string.Empty;
            switch (estado)
            {
                case "Completado": return Brush("#22C55E");
                case "Pausado": return Brush("#F59E0B");
                default: return Brush("#3B82F6");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        private static SolidColorBrush Brush(string hex)
        {
            var b = (SolidColorBrush)new BrushConverter().ConvertFromString(hex);
            b.Freeze();
            return b;
        }
    }

    /// <summary>
    /// Convierte el tipo de una notificación en el color de su punto indicador.
    /// Tipos: Info | Alerta | Urgente | Neutral | Exito
    /// </summary>
    public class NotifTipoToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string tipo = value as string ?? string.Empty;
            switch (tipo)
            {
                case "Info": return Brush("#5468D6");
                case "Alerta": return Brush("#F59E0B");
                case "Urgente": return Brush("#EF4444");
                case "Exito": return Brush("#22C55E");
                default: return Brush("#9CA3AF");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        private static SolidColorBrush Brush(string hex)
        {
            var b = (SolidColorBrush)new BrushConverter().ConvertFromString(hex);
            b.Freeze();
            return b;
        }
    }

    /// <summary>Convierte un string a hex de color directamente en un SolidColorBrush (para colores dinámicos guardados como texto en el modelo).</summary>
    public class HexToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string hex = value as string;
            if (string.IsNullOrEmpty(hex)) return Brushes.Transparent;
            try
            {
                var b = (SolidColorBrush)new BrushConverter().ConvertFromString(hex);
                b.Freeze();
                return b;
            }
            catch
            {
                return Brushes.Transparent;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
