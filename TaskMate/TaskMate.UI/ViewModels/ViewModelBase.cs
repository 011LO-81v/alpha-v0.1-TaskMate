using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TaskMate.ViewModels
{
    /// <summary>
    /// Clase base para todos los ViewModels. Implementa INotifyPropertyChanged
    /// para permitir el enlace de datos reactivo (data binding) en la UI.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
