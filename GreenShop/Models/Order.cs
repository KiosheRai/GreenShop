using System;

namespace GreenShop.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Status Status { get; set; } 
        public DateTime OrderDate { get; set; }
        public virtual User User { get; set; }
    }
}
