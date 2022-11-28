using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GreenShop.Models
{
    public class Good : INotifyPropertyChanged
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }
        public decimal Price { get; set; }
        public virtual Category Category { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
