using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GreenShop.Messages;
using GreenShop.Service;
using GreenShop.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GreenShop.ViewModels
{
    internal class StartViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly GreenShopManager _manager;
        private IMessenger _messanger;

        private RelayCommand basketCommand = null;
        private RelayCommand registrationCommand = null;

        private string description;
        private string name;
        private string price;

        public Visibility ViaError { get; set; }
        public Visibility ViaLogin { get; set; }
        public Visibility ViaPassword { get; set; }

        public bool IsEnable { get; set; }

        public string Description
        {
            get => description;
            set { description = value; }
        }

        public string Password
        {
            get => name;
            set { name = value; }
        }

        public string Price
        {
            get => price;
            set { price = value; }
        }

        public StartViewModel(GreenShopManager manager, IMessenger messenger)
        {
            (_manager, _messanger) = (manager, messenger);
        }

        public RelayCommand BasketCommand => basketCommand ??= new RelayCommand(() =>
        {
            var user = _manager.GetUserWithPassword(Description, Password);

            if (user == null)
            {
                ViaError = Visibility.Visible;
                return;
            }
            else
            {
                ViaError = Visibility.Hidden;
            }

            _messanger.Send(new LoginUserMessage() { User = user });
            _messanger.Send(new NavigationMessage() { ViewModelType = typeof(RegisterViewModel) });
        });
        public RelayCommand RegistrationCommand => registrationCommand ??= new RelayCommand(() =>
        {
            _messanger.Send(new NavigationMessage { ViewModelType = typeof(RegisterViewModel) });
        });
    }
}
