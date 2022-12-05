using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GreenShop.Service;
using GreenShop.ViewModels;
using SimpleInjector;
using System.Windows;

namespace GreenShop
{
    public partial class App : Application
    {
        public static Container Services { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            RegisterServices();
                Start<LoginViewModel>();
        }

        private void Start<T>() where T : ViewModelBase
        {
            var windowViewModel = Services.GetInstance<MainViewModel>();
            windowViewModel.CurrentViewModel = Services.GetInstance<T>();

            var mainWindow = new MainWindow { DataContext = windowViewModel };
            mainWindow.ShowDialog();
        }

        public void RegisterServices()
        {
            Services = new Container();
            Services.RegisterSingleton<GreenShopManager>();
            Services.RegisterSingleton<IMessenger, Messenger>();
            Services.RegisterSingleton<MainViewModel>();
            Services.RegisterSingleton<LoginViewModel>();
            Services.RegisterSingleton<RegisterViewModel>();
            Services.RegisterSingleton<ListGoodsViewModel>();

            Services.Verify();
        }
    }
}
