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
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=GreenShop;Integrated Security=True");
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
                    new Good{Id = Guid.Parse("BAA4F333-1FFE-4E3C-AD98-1F9064ED7DD3"), Name = "Cold cup", Price = 1, Description = "Completely natural!", ImgPath = "Pictures/Coldcup.jpg" },
                    new Good{Id = Guid.Parse("A77EB77F-1458-44D1-BCB4-6D19AD6C401E"), Name = "Square plate", Price = 14, Description = "Food becomes more delicious!", ImgPath = "Pictures/Squareplate.jpg" },
                    new Good{Id = Guid.Parse("C0E0114D-8EB3-47D0-89CF-50F93D477998"), Name = "T-shirt", Price = 6, Description = "It is made of leaves!", ImgPath = "Pictures/T-shirt.jpg" },
                    new Good{Id = Guid.Parse("12689D87-6268-4A99-BE40-F0A932B05623"), Name = "Basket", Price = 25, Description = "Eco-busket for eco-rubbish!", ImgPath = "Pictures/Basket.jpg" },
                    new Good{Id = Guid.Parse("EACB55C3-4E59-484B-B02E-9579B724D2A3"), Name = "Red flower", Price = 13, Description = "Great for a gift!", ImgPath = "Pictures/Redflower.jpg" },
                    new Good{Id = Guid.Parse("2919F112-C2AE-4628-B0A0-FA72A3601C62"), Name = "White flower", Price = 13, Description = "Smells like winter!", ImgPath = "Pictures/Whiteflower.jpg" },
                    new Good{Id = Guid.Parse("00C5E8D5-36AB-48D2-B220-E88182F8E776"), Name = "Purple flower", Price = 13, Description = "Great for a gift!", ImgPath = "Pictures/Purpleflower.jpg" },
                    new Good{Id = Guid.Parse("C2B040AC-4901-461D-B0E4-D4E32969D683"), Name = "Yellow flower", Price = 13, Description = "Smells like autumn!", ImgPath = "Pictures/Yellowflower.jpg" },
                    new Good{Id = Guid.Parse("C8134484-ACC0-4D7B-A8BA-6E5AAB103054"), Name = "Crisps", Price = 6, Description = "Very crispy and natural!", ImgPath = "Pictures/Crisps.jpg" },
                    new Good{Id = Guid.Parse("AB3CB0FE-C134-4444-B417-79EBFFE1240E"), Name = "Crackers", Price = 5, Description = "Yummy!", ImgPath = "Pictures/Crackers.jpg" },
                    new Good{Id = Guid.Parse("7F142B94-CD54-4BC7-97F2-F688A1E49D7A"), Name = "Glass", Price = 9, Description = "The most transparent glass!", ImgPath = "Pictures/Glass.jpg" },
                    new Good{Id = Guid.Parse("E0AA6EC2-6A9E-4726-A0CB-DE2DC67447A0"), Name = "Scoop", Price = 5, Description = "Perfectly suit for soup!", ImgPath = "Pictures/Scoop.jpg" },
                    new Good{Id = Guid.Parse("58043D33-D186-4625-A84D-7CEFA15FB8E6"), Name = "Paper towel", Price = 3, Description = "Let everything be dry!", ImgPath = "Pictures/Papertowel.jpg" },
                    new Good{Id = Guid.Parse("75CC1462-CD9A-4A25-A94F-713C5A98B381"), Name = "Pillow", Price = 12, Description = "It is very soft!", ImgPath = "Pictures/Pillow.jpg" },
                });

            base.OnModelCreating(builder);
        }
    }
}
