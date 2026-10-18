using System.Windows;
using TaskMate.UI.ViewModels;

namespace TaskMate.UI
{
    public partial class DashboardWindow : Window
    {
        public DashboardWindow()
        {
            InitializeComponent();

            if (DataContext is DashboardViewModel viewModel)
            {
                viewModel.OnLogout = () =>
                {
                    MainWindow loginWindow = new MainWindow();
                    loginWindow.Show();
                    this.Close();
                };
            }
        }
    }
}
