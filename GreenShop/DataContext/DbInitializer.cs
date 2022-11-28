using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenShop.DataContext
{
    public class DbInitializer
    {
        public static void Initialize(GreenShopDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
