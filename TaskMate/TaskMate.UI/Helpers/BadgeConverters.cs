using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace TaskMate.UI.Helpers
{
    /// <summary>
    /// Convierte una etiqueta de texto (Prioridad o Estado) en el color de FONDO
    /// correspondiente a la "píldora" (badge) que se ve en las capturas de diseño.
    /// </summary>
    public class BadgeBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string key = value as string ?? string.Empty;
            switch (key)
            {
                case "Baja": return Brush("#DBEAFE");
                case "Media": return Brush("#FEF3C7");
                case "Alta": return Brush("#FEE2E2");
                case "Urgente": return Brush("#FECACA");
                case "Activo": return Brush("#D1FAE5");
                case "Pausado": return Brush("#FEF3C7");
                case "Completado": return Brush("#DBEAFE");
                case "Completada": return Brush("#DBEAFE");
                case "Pendiente": return Brush("#F3F4F6");
                case "En progreso": return Brush("#DBEAFE");
                case "En revisión": return Brush("#FEF3C7");
                case "Acción Requerida": return Brush("#FEE2E2");
                default: return Brush("#F3F4F6");
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
    /// Convierte una etiqueta de texto (Prioridad o Estado) en el color de TEXTO
    /// correspondiente a la "píldora" (badge).
    /// </summary>
    public class BadgeForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string key = value as string ?? string.Empty;
            switch (key)
            {
                case "Baja": return Brush("#2563EB");
                case "Media": return Brush("#D97706");
                case "Alta": return Brush("#DC2626");
                case "Urgente": return Brush("#B91C1C");
                case "Activo": return Brush("#059669");
                case "Pausado": return Brush("#D97706");
                case "Completado": return Brush("#2563EB");
                case "Completada": return Brush("#2563EB");
                case "Pendiente": return Brush("#4B5563");
                case "En progreso": return Brush("#2563EB");
                case "En revisión": return Brush("#D97706");
                case "Acción Requerida": return Brush("#DC2626");
                default: return Brush("#4B5563");
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
    /// Compara el valor enlazado (p.ej. "MiUsuario") contra el ConverterParameter.
    /// Si coinciden, devuelve el pincel "activo" del sidebar; si no, "Transparent".
    /// Se usa para resaltar la opción de menú seleccionada.
    /// </summary>
    public class StringEqualsToActiveBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string current = value as string;
            string key = parameter as string;
            bool isActive = current != null && current == key;
            return isActive ? Brush("#EEF1FE") : Brushes.Transparent;
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

    public class StringEqualsToActiveForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string current = value as string;
            string key = parameter as string;
            bool isActive = current != null && current == key;
            return isActive ? Brush("#5468D6") : Brush("#4B5563");
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
    /// Compara el valor enlazado contra el ConverterParameter y devuelve un bool.
    /// Útil para IsChecked de ToggleButtons que representan pestañas/chips seleccionables.
    /// </summary>
    public class StringEqualsToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string current = value as string;
            string key = parameter as string;
            return current != null && current == key;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isChecked = value is bool && (bool)value;
            return isChecked ? (parameter as string) : Binding.DoNothing;
        }
    }

    /// <summary>
    /// Convierte true/false en Visibility (Visible/Collapsed).
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool b = value is bool && (bool)value;
            if (parameter as string == "Invert") b = !b;
            return b ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    /// <summary>
    /// Devuelve Visible si el string enlazado no es nulo/vacío; Collapsed en caso contrario.
    /// Se usa para mostrar/ocultar chips de etiqueta opcionales (p.ej. en el calendario).
    /// </summary>
    public class StringNotEmptyToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string s = value as string;
            return string.IsNullOrEmpty(s) ? System.Windows.Visibility.Collapsed : System.Windows.Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    /// <summary>
    /// Convierte un porcentaje (0-100) en un GridLength proporcional al ancho total,
    /// usado para dibujar barras de progreso "a mano" sin controles externos.
    /// </summary>
    public class PercentToWidthConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                double percent = System.Convert.ToDouble(values[0]);
                double totalWidth = System.Convert.ToDouble(values[1]);
                return totalWidth * (percent / 100.0);
            }
            catch
            {
                return 0.0;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
