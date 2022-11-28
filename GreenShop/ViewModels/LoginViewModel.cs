using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GreenShop.Messages;
using GreenShop.Service;

namespace GreenShop.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly GreenShopManager _manager;
        private IMessenger _messanger;

        private RelayCommand loginCommand = null;
        private RelayCommand registrationCommand = null;

        private string login;
        private string password;

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

        public LoginViewModel(GreenShopManager manager, IMessenger messenger) =>
            (_manager, _messanger) = (manager, messenger);

        public RelayCommand LoginCommand => loginCommand ??= new RelayCommand(() =>
        {
            var user = _manager.GetUserWithPassword(login, password);

            if(user == null)
            {
                throw new System.Exception();
            }

            _messanger.Send(new LoginUserMessage() { User = user });

            _messanger.Send(new NavigationMessage() { ViewModelType = typeof(RegisterViewModel) });
        });

        private void Check()
        {
            bool isCorrect = true;

            if (login.Trim() == string.Empty)
                isCorrect = false;

            if (password.Trim() == string.Empty)
                isCorrect = false;

            IsEnable = isCorrect;
        }

        public RelayCommand RegistrationCommand => registrationCommand ??= new RelayCommand(() =>
        {
            _messanger.Send(new NavigationMessage { ViewModelType = typeof(RegisterViewModel) });
        });
    }
}
