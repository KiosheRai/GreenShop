using GalaSoft.MvvmLight.Messaging;
using GreenShop.Models;

namespace GreenShop.Messages
{
    public class LoginUserMessage : Messenger
    {
        public User User { get; set; }
    }
}
