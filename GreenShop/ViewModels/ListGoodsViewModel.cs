using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GreenShop.Messages;
using GreenShop.Models;
using GreenShop.Service;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace GreenShop.ViewModels
{
    internal class ListGoodsViewModel : ViewModelBase
    {
        private IMessenger _messanger;
        private GreenShopManager _manager;
        public User user;

        public ObservableCollection<GoodsList> Basket { get; set; }

        public ObservableCollection<Good> Goods { get; set;}

        public ListGoodsViewModel(GreenShopManager manager, IMessenger messenger)
        {
            (_manager, _messanger) = (manager, messenger);

            Basket = new ObservableCollection<GoodsList>();

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
                    Count = 1
                };
                Basket.Add(goodsList);
            }
            else
            {
                int index = Basket.IndexOf(element);
                Basket[index].Count += 1;
                RaisePropertyChanged("Basket");
            }
            
        });

        private RelayCommand basketCommand = null;
        public RelayCommand BasketCommand => basketCommand ??= new RelayCommand(() =>
        {
            _messanger.Send(new NavigationMessage() { ViewModelType = typeof(RegisterViewModel) });
        });

        private RelayCommand registrationCommand = null;
        public RelayCommand RegistrationCommand => registrationCommand ??= new RelayCommand(() =>
        {
            _messanger.Send(new NavigationMessage { ViewModelType = typeof(RegisterViewModel) });
        });

        public void UpdateDate()
        {
            Goods = new ObservableCollection<Good>(_manager.GetGoods());
        }
    }
}


