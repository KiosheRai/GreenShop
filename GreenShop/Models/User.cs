using System;

namespace GreenShop.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Phone { get; set; }
        public string? Email { get; set; }
        public string Address { get; set; }
        public virtual Role Role { get; set; }
    }
}
