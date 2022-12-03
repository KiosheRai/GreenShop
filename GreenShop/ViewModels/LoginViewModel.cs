using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GreenShop.Messages;
using GreenShop.Service;
using System.ComponentModel;
using System.Windows;

namespace GreenShop.ViewModels
{
    public class LoginViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly GreenShopManager _manager;
        private IMessenger _messanger;

        private RelayCommand loginCommand = null;
        private RelayCommand registrationCommand = null;

        private string login;
        private string password;

        public Visibility ViaError { get; set; }
        public Visibility ViaLogin { get; set; }
        public Visibility ViaPassword { get; set; }

        public bool IsEnable { get; set; }

        public string Login
        {
            get => login;
            set { login = value; Check(); }
        }

        public string Password
        {
            get => password;
            set { password = value; Check(); }
        }

        public LoginViewModel(GreenShopManager manager, IMessenger messenger)
        {
            (_manager, _messanger) = (manager, messenger);
            Clear();
        }

        public RelayCommand LoginCommand => loginCommand ??= new RelayCommand(() =>
        {
            var user = _manager.GetUserWithPassword(Login, Password);

            if(user == null)
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

        private void Check()
        {
            bool isCorrect = true;

            if (string.IsNullOrEmpty(Login))
            {
                isCorrect = false;
                ViaLogin = Visibility.Visible;
            }
            else
            {
                ViaLogin = Visibility.Collapsed;
            }
                

            if (string.IsNullOrEmpty(Password))
            {
                isCorrect = false;
                ViaPassword = Visibility.Visible;
            }
            else
            {
                ViaPassword = Visibility.Collapsed;
            }

            IsEnable = isCorrect;
        }

        private void Clear()
        {
            login = string.Empty;
            password = string.Empty;
            ViaError = Visibility.Hidden;
        }

        public RelayCommand RegistrationCommand => registrationCommand ??= new RelayCommand(() =>
        {
            _messanger.Send(new NavigationMessage { ViewModelType = typeof(RegisterViewModel) });
        });
    }
}
