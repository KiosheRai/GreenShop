using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GreenShop.Messages;

namespace GreenShop.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(IMessenger messenger)
        {
            messenger.Register<NavigationMessage>(this, message =>
            {
                var viewModel = App.Services.GetInstance(message.ViewModelType) as ViewModelBase;
                CurrentViewModel = viewModel;
            });
        }
        private ViewModelBase currentViewModel;

        public ViewModelBase CurrentViewModel { get => currentViewModel; set => Set(ref currentViewModel, value); }

    }
}
