using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GreenShop.Messages;
using GreenShop.Models;
using GreenShop.Service;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace GreenShop.ViewModels
{
    internal class ListGoodsViewModel : ViewModelBase
    {
        private IMessenger _messanger;
        private GreenShopManager _manager;
        public User user;

        public ObservableCollection<GoodsList> Basket { get; set; }

        public ObservableCollection<Good> Goods { get; set;}

        public Order order { get; set; }

        public bool IsConfirmEnabled { get; set; }

        public ListGoodsViewModel(GreenShopManager manager, IMessenger messenger)
        {
            (_manager, _messanger) = (manager, messenger);

            Basket = new ObservableCollection<GoodsList>();

            order = new Order
            {
                Id = Guid.NewGuid(),
                Status = Status.Basket
            };

            IsConfirmEnabled = false;

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

        private RelayCommand<Guid> addCommand = null;
        public RelayCommand<Guid> AddCommand => addCommand ??= new RelayCommand<Guid>((id) =>
        {
            var element = Basket.FirstOrDefault(x => x.Good.Id == id);
            if(element == null)
            {
                var goodsList = new GoodsList
                {
                    Id = Guid.NewGuid(),
                    Good = _manager.GetGoodById(id),
                    Order = order,
                    Count = 1
                };
                Basket.Add(goodsList);
            }
            else
            {
                Basket.Remove(element);
                element.Count += 1;
                Basket.Add(element);
            }
            Validate();
        });

        private RelayCommand<Guid> removeCommand = null;
        public RelayCommand<Guid> RemoveCommand => removeCommand ??= new RelayCommand<Guid>((id) =>
        {
            var element = Basket.First(x => x.Id == id);
            if (element.Count == 1)
            {
                Basket.Remove(element);
            }
            else
            {
                Basket.Remove(element);
                element.Count -= 1;
                Basket.Add(element);
            }
            Validate();
        });

        private RelayCommand confirmCommand = null;
        public RelayCommand ConfirmCommand => confirmCommand ??= new RelayCommand(() =>
        {
            if(Basket.Count > 0)
            {
                decimal sum = Basket.Sum(x => x.Count * x.Good.Price);
                
                MessageBoxResult result = MessageBox.Show($"Are you sure? Total price is {sum}", "Info", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);

                if(result == MessageBoxResult.Yes)
                {
                    order.User = user;
                    _manager.AddOrder(Basket.ToList(), order);
                    Basket = new ObservableCollection<GoodsList>();
                }
            }
        });

        private RelayCommand basketCommand = null;
        public RelayCommand BasketCommand => basketCommand ??= new RelayCommand(() =>
        {
            _messanger.Send(new NavigationMessage() { ViewModelType = typeof(RegisterViewModel) });
        });

        private RelayCommand logoutCommand = null;
        public RelayCommand LogoutCommand => logoutCommand ??= new RelayCommand(() =>
        {
            _messanger.Send(new NavigationMessage { ViewModelType = typeof(LoginViewModel) });
        });

        private void Validate()
        {
            if (Basket.Count > 0)
                IsConfirmEnabled = true;
            else
                IsConfirmEnabled = false;
        }

        public void UpdateDate()
        {
            Goods = new ObservableCollection<Good>(_manager.GetGoods());
        }
    }
}


