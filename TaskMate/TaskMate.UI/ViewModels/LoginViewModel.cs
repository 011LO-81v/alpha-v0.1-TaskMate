using System.ComponentModel;
using System;
using System.Windows;
using System.Windows.Input;
using TaskMate.Services;
using TaskMate.UI.Helpers;

namespace TaskMate.UI.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly UsuarioService _usuarioService;
        private string _correo;
        private string _mensajeError;

        public string Correo
        {
            get => _correo;
            set { _correo = value; OnPropertyChanged(nameof(Correo)); }
        }

        public string MensajeError
        {
            get => _mensajeError;
            set { _mensajeError = value; OnPropertyChanged(nameof(MensajeError)); }
        }

        public ICommand LoginCommand { get; }

        public Action OnLoginSuccess { get; set; }

        public LoginViewModel()
        {
            _usuarioService = new UsuarioService();
            LoginCommand = new RelayCommand(EjecutarLogin);
        }

        private void EjecutarLogin(object parameter)
        {
            // Extraemos la contraseña directamente del control visual por seguridad
            var passwordBox = parameter as System.Windows.Controls.PasswordBox;
            string password = passwordBox?.Password;

            if (string.IsNullOrWhiteSpace(Correo) || string.IsNullOrWhiteSpace(password))
            {
                MensajeError = "Por favor, ingresa correo y contraseña.";
                return;
            }

            bool accesoConcedido = _usuarioService.Authenticate(Correo, password);

            if (accesoConcedido)
            {
                MensajeError = "";
                // Disparamos la acción de éxito que será escuchada por la ventana
                OnLoginSuccess?.Invoke();
            }
            else
            {
                MensajeError = "Correo o contraseña incorrectos.";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
