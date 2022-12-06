using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GreenShop.Messages;
using GreenShop.Models;
using GreenShop.Service;
using System;
using System.Collections.ObjectModel;

namespace GreenShop.ViewModels
{
    internal class AdminViewModel : ViewModelBase
    {
        private IMessenger _messanger;
        private GreenShopManager _manager;

        public User User { get; set; }

        public ObservableCollection<Order> Orders { get; set; }

        public AdminViewModel(GreenShopManager manager, IMessenger messenger)
        {
            (_manager, _messanger) = (manager, messenger);

            _messanger.Register<LoginUserMessage>(this, msg =>
            {
                User = msg.User;
            });

            _messanger.Register<UpdateData>(this, (obj) =>
            {
                UpdateDate();
            });
        }

        private void UpdateDate()
        {
            if(User.Email == null)
                User.Email = string.Empty;

            Orders = new ObservableCollection<Order>(_manager.GetOrdersByUser(User.Id));
        }
    }
}
