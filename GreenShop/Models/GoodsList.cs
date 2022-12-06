using System;

namespace GreenShop.Models
{
    public class GoodsList
    {
        public Guid Id { get; set; }
        public virtual Good Good { get; set; }
        public virtual Order Order { get; set; }
        public int Count { get; set; }
    }
}
