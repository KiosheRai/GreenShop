using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GreenShop.Service;

namespace GreenShop.ViewModels
{
    internal class AdminViewModel : ViewModelBase
    {
        private IMessenger _messanger;
        private GreenShopManager _manager;

        public AdminViewModel(GreenShopManager manager, IMessenger messenger) =>
            (_manager, _messanger) = (manager, messenger);


    }
}
