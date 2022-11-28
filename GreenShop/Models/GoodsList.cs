using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GreenShop.Models
{
    public class GoodsList : INotifyPropertyChanged
    {
        public Guid Id { get; set; }
        public virtual Order Order { get; set; }
        public virtual Good Good { get; set; }
        public int Amount { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
