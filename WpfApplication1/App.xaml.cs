using System.Windows;
using WPF_GUI.ViewModels;

namespace GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow window = new MainWindow();
            ViewModelWinnersList vm = new ViewModelWinnersList();
            window.DataContext = vm;
            window.Show();
        }
    }
}
