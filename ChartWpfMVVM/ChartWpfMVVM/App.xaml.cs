using ChartWpfMVVM.Interfaces;
using ChartWpfMVVM.Services;
using ChartWpfMVVM.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace ChartWpfMVVM
{
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;
        public App()
        {
            var services = new ServiceCollection();

            services.AddTransient<MainWindowViewModel>();
            services.AddScoped(s => new MainWindow { DataContext = s.GetRequiredService<MainWindowViewModel>() });

            services.AddSingleton<IUserDialogServise, UserDialogService>();

            _serviceProvider = services.BuildServiceProvider();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _serviceProvider.GetRequiredService<IUserDialogServise>().OpenMainWindow();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _serviceProvider.Dispose();
            base.OnExit(e);
        }
    }

}
