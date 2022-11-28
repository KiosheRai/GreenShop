using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GreenShop.Models
{
    public class Order : INotifyPropertyChanged
    {
        public Guid Id { get; set; }
        public Status Status { get; set; } 
        public virtual User User { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
