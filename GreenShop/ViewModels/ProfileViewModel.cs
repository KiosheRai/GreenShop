using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GreenShop.Messages;
using GreenShop.Models;
using GreenShop.Service;
using System.Collections.ObjectModel;
using System.Windows;

namespace GreenShop.ViewModels
{
    internal class ProfileViewModel : ViewModelBase
    {
        private IMessenger _messanger;
        private GreenShopManager _manager;

        public User User { get; set; }
        public ObservableCollection<Order> Orders { get; set; }

        private string oldPassword;
        private string newPassword;
        private string newPasswordConfirm;

        public string OldPassword
        {
            get { return oldPassword; }
            set { oldPassword = value; Validate(); }
        }
        public string NewPassword
        {
            get { return newPassword; }
            set { newPassword = value; Validate(); }
        }
        public string NewPasswordConfirm
        {
            get { return newPasswordConfirm; }
            set { newPasswordConfirm = value; Validate(); }
        }

        public bool IsEnable { get; set; }

        public Visibility ViaOldPassword { get; set; }
        public Visibility ViaNewPassword { get; set; }
        public Visibility ViaNewPasswordConfirm { get; set; }

        public ProfileViewModel(GreenShopManager manager, IMessenger messenger)
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

        private void Validate()
        {
            bool isCorrect = true;

            if (string.IsNullOrEmpty(oldPassword))
            {
                isCorrect = false;
                ViaOldPassword = Visibility.Visible;
            }
            else
            {
                ViaOldPassword = Visibility.Collapsed;
            }

            if(newPassword.Length < 5 || newPassword == oldPassword)
            {
                isCorrect = false;
                ViaNewPassword = Visibility.Visible;
            }
            else
            {
                ViaNewPassword = Visibility.Collapsed;
            }

            if (!newPasswordConfirm.Equals(newPassword))
            {
                isCorrect = false;
                ViaNewPasswordConfirm = Visibility.Visible;
            }
            else
            {
                ViaNewPasswordConfirm = Visibility.Collapsed;
            }

            IsEnable = isCorrect;
        }

        private void UpdateDate()
        {
            oldPassword = string.Empty;
            newPassword = string.Empty;
            newPasswordConfirm = string.Empty;
            IsEnable = false;

            if (User.Email == null)
                User.Email = string.Empty;

            Orders = new ObservableCollection<Order>(_manager.GetOrdersByUser(User.Id));
        }
    }
}
