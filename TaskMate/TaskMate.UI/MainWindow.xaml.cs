using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TaskMate.UI.ViewModels;

namespace TaskMate.UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Capturamos el ViewModel que conectamos en el XAML
            if (DataContext is LoginViewModel viewModel)
            {
                // Le decimos qué hacer cuando el inicio de sesión sea exitoso
                viewModel.OnLoginSuccess = () =>
                {
                    // 1. Creamos la nueva ventana
                    DashboardWindow dashboard = new DashboardWindow();

                    // 2. La mostramos en pantalla
                    dashboard.Show();

                    // 3. Cerramos esta ventana de Login
                    this.Close();
                };
            }
        }
    }
}
