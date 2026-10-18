using System;
using System.ComponentModel;
using System.Windows.Input;
using TaskMate.Services;
using TaskMate.UI.Helpers;

namespace TaskMate.UI.ViewModels
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        public string NombreUsuario => SessionManager.Instance.CurrentUser != null
            ? SessionManager.Instance.CurrentUser.Nombre
            : "Usuario";

        public string RolUsuario => SessionManager.Instance.CurrentUser != null
            ? SessionManager.Instance.CurrentUser.Rol
            : "Miembro";

        public ICommand LogoutCommand { get; }

        public Action OnLogout { get; set; }

        public DashboardViewModel()
        {
            LogoutCommand = new RelayCommand(EjecutarLogout);
        }

        private void EjecutarLogout(object parameter)
        {
            SessionManager.Instance.Logout();
            OnLogout?.Invoke();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}