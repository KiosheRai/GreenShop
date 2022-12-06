using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GreenShop.Messages;
using GreenShop.Models;
using GreenShop.Service;
using System.ComponentModel;
using System.Windows;

namespace GreenShop.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private readonly GreenShopManager _manager;
        private IMessenger _messanger;

        private RelayCommand registrationCommand = null;
        private RelayCommand loginCommand = null;

        private string login;
        private string phone;
        private string email;
        private string password;
        private string passwordConfirm;
        private string address;

        public bool IsEnable { get; set; }

        public Visibility ViaLogin { get; set; }
        public Visibility ViaPhone { get; set; }
        public Visibility ViaEmail { get; set; }
        public Visibility ViaPassword { get; set; }
        public Visibility ViaPasswordConfirm { get; set; }
        public Visibility ViaAddress { get; set; }
        public Visibility ViaError { get; set; }

        public string Login
        {
            get => login;
            set { login  = value; Validate(); }
        }

        public string Phone
        {
            get => phone;
            set { phone = value; Validate(); }
        }

        public string Email
        {
            get => email;
            set { email = value; Validate(); }
        }

        public string Password
        {
            get => password;
            set { password = value; Validate(); }
        }

        public string PasswordConfirm
        {
            get => passwordConfirm;
            set { passwordConfirm = value; Validate(); }
        }

        public string Address
        {
            get => address;
            set { address = value; Validate(); }
        }

        public RegisterViewModel(IMessenger messanger, GreenShopManager manager)
        {
            (_messanger, _manager) = (messanger, manager);
            Clear();
        }

        public RelayCommand RegistrationCommand => registrationCommand ??= new RelayCommand( () =>
        {
            if (_manager.IsUserExists(login))
            {
                ViaError = Visibility.Visible;
                return;
            }
            else
            {
                ViaError = Visibility.Collapsed;
            }

            User user = new User
            {
                Login = login,
                Password = password,
                Address = Address,
                Phone = phone,
                Email = Email,
            };

            _manager.RegisterUser(user);

            _messanger.Send(new NavigationMessage() { ViewModelType = typeof(LoginViewModel) });
            Clear();
        });

        private void Validate()
        {
            bool isCorrect = true;

            if (Login.Trim().Length < 5)
            {
                ViaLogin = Visibility.Visible;
                isCorrect = false;
            }
            else
            {
                ViaLogin = Visibility.Collapsed;
            }

            if (!Validator.IsPhone(phone))
            {
                ViaPhone = Visibility.Visible;
                isCorrect = false;
            }
            else
            {
                ViaPhone = Visibility.Collapsed;
            }

            if (email != string.Empty && !Validator.IsEmail(email))
            {
                ViaEmail = Visibility.Visible;
                isCorrect = false;
            }
            else
            {
                ViaEmail = Visibility.Collapsed;
            }

            if(password.Length < 5)
            {
                ViaPassword = Visibility.Visible;
                isCorrect = false;
            }
            else
            {
                ViaPassword = Visibility.Collapsed;
            }
            
            if(password != passwordConfirm)
            {
                ViaPasswordConfirm = Visibility.Visible;
                isCorrect = false;
            }
            else
            {
                ViaPasswordConfirm = Visibility.Collapsed;
            }

            if (address == string.Empty)
            {
                ViaAddress = Visibility.Visible;
                isCorrect = false;
            }
            else
            {
                ViaAddress = Visibility.Collapsed;
            }

            IsEnable = isCorrect;
        }

        private void Clear()
        {
            login = string.Empty;
            phone = string.Empty;
            password = string.Empty;
            passwordConfirm = string.Empty;
            email = string.Empty;
            address = string.Empty;
            phone = string.Empty;
            IsEnable = false;
            ViaError = Visibility.Hidden;
        }

        public RelayCommand LoginCommand => loginCommand ??= new RelayCommand(() =>
        {
            _messanger.Send(new NavigationMessage() { ViewModelType = typeof(LoginViewModel) });
            Clear();
        });
    }
}
