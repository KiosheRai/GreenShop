using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GreenShop.Messages;
using GreenShop.Models;
using GreenShop.Service;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GreenShop.ViewModels
{
    internal class ListGoodsViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private IMessenger _messanger;
        private GreenShopManager _manager;
        public User user;

        private RelayCommand basketCommand = null;
        private RelayCommand registrationCommand = null;

        public ListGoodsViewModel(GreenShopManager manager, IMessenger messenger)
        {
            (_manager, _messanger) = (manager, messenger);

            _messanger.Register<LoginUserMessage>(this, msg =>
            {
                user = msg.User;
            });

            _messanger.Register<UpdateData>(this, (obj) =>
            {
                UpdateDate();
                //if (User.Position.Name.Equals("Admin")) IsAdmin = Visibility.Visible;
                //else IsAdmin = Visibility.Collapsed;
            });
        }

        public RelayCommand BasketCommand => basketCommand ??= new RelayCommand(() =>
        {
            
            _messanger.Send(new NavigationMessage() { ViewModelType = typeof(RegisterViewModel) });
        });
        public RelayCommand RegistrationCommand => registrationCommand ??= new RelayCommand(() =>
        {
            _messanger.Send(new NavigationMessage { ViewModelType = typeof(RegisterViewModel) });
        });

        public void UpdateDate()
        {
            Goods = new ObservableCollection<Good>(_manager.GetGoods());
        }

        public ObservableCollection<Good> Goods { get; set; }
    }
}
