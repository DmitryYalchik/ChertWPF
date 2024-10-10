using Microsoft.Extensions.DependencyInjection;
using ChartWpfMVVM.Interfaces;
using System.Windows;

namespace ChartWpfMVVM.Services
{
    public class UserDialogService : IUserDialogServise
    {
        private readonly IServiceProvider _service;

        public UserDialogService(IServiceProvider service) => _service = service;

        private void OpenWindow<T>(ref T? window) where T : Window
        {
            if (window != null)
            {                
                window.Show();
                return;
            }

            window = _service.GetRequiredService<T>();

            switch (window)
            {
                case MainWindow:
                    window.Closed += (_, _) => _mainWindow = null;
                    _mainWindow = (MainWindow)((Window)window);
                    break;
                default:
                    break;
            }

            window.Show();
        }
        private T OpenDialogWindow<T>(ref T? window) where T : Window
        {
            if (window != null)
            {
                window.ShowDialog();
                return window;
            }

            window = _service.GetRequiredService<T>();
            window.Closed += Window_Closed;
            window.ShowDialog();

            return window;
        }
        private void Window_Closed(object? sender, EventArgs e)
        {
            if (sender is Window closedWindow)
            {
                //closedWindow.Close();
                closedWindow = null;
            }
        }

        ///////////////////////////////////////////////////////////////////////////
        
        private MainWindow? _mainWindow;
        public void OpenMainWindow() => OpenWindow(ref _mainWindow);

    }
}
