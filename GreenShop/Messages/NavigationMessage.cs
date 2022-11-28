using GalaSoft.MvvmLight.Messaging;
using System;

namespace GreenShop.Messages
{
    public class NavigationMessage : Messenger
    {
        public Type ViewModelType { get; set; }
    }
}
