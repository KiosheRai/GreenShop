using GreenShop.DataContext.EntityTypeConfigurations;
using GreenShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GreenShop.DataContext
{
    public class GreenShopDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Good> Goods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<GoodsList> GoodsLists { get; set; }

        public GreenShopDbContext()
        {
            Database.EnsureCreated();

            var admin = new User
            {
                Id = Guid.NewGuid(),
                Login = "Admin",
                Password = "c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f",
                Address = "Null",
                Phone = "+375291112323",
                Role = Roles.First(x => x.Id == Guid.Parse("F9CE75EC-F6DF-4656-ABB0-C245BECA1A99"))
            };

            Users.Add(admin);

            SaveChanges();
        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=MAXIMINSPIRON17\\SQLEXPRESS;Initial Catalog=GreenShop;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GoodConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());

            builder.Entity<Role>().HasData(
                new Role[]
                {
                    new Role{ Id = Guid.Parse("50D40CB8-17C6-4829-9505-5D99AE9E0F66"), Name = "Default" },
                    new Role{ Id = Guid.Parse("F9CE75EC-F6DF-4656-ABB0-C245BECA1A99"), Name = "Admin" },
                });

            builder.Entity<Good>().HasData(
                new Good[]
                {
                    new Good{Id = Guid.Parse("706ED2A5-9491-40B1-A3DB-2BCA2B2DF5AB"), Name = "Apple", Price = 200, Description = "И по сей день в центральных регионах звучит перекатами шёпот бессменных лидеров", ImgPath = "null" },
                    new Good{Id = Guid.Parse("689B0690-AB37-4F81-A1E6-C5824CD008DE"), Name = "Banana", Price = 500, Description = "Постоянный количественный рост ни к чему нас не обязывает", ImgPath = "null" },
                    new Good{Id = Guid.Parse("5878DC77-F7DC-437B-B1E6-CB0B8FD1083B"), Name = "Potato", Price = 50, Description = "Оказывается, прототип — не панацея!", ImgPath = "null" },
                });

            base.OnModelCreating(builder);
        }
    }
}
