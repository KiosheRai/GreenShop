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
                    new Good{Id = Guid.Parse("706ED2A5-9491-40B1-A3DB-2BCA2B2DF5AB"), Name = "Apple", Price = 200, Description = "You can eat and make a fire!", ImgPath = "Pictures/Apple.jpg" },
                    new Good{Id = Guid.Parse("689B0690-AB37-4F81-A1E6-C5824CD008DE"), Name = "Banana", Price = 500, Description = "Постоянный количественный рост ни к чему нас не обязывает", ImgPath = "Pictures/Banana.jpg" },
                    new Good{Id = Guid.Parse("5878DC77-F7DC-437B-B1E6-CB0B8FD1083B"), Name = "Potato", Price = 50, Description = "Оказывается, прототип — не панацея!", ImgPath = "Pictures/Potato.jpg" },
                    new Good{Id = Guid.Parse("D88C7689-D301-480F-8F08-1AED4A3B4FCB"), Name = "Wooden forks", Price = 5, Description = "You can eat and make a fire!", ImgPath = "Pictures/Woodenforks.jpg" },
                    new Good{Id = Guid.Parse("1DA708A3-3AE1-4E4A-A931-291162B2BB71"), Name = "Face mask", Price = 33, Description = "Cleans better than a brush!", ImgPath = "Pictures/Facemask.jpg" },
                    new Good{Id = Guid.Parse("910CAD85-55E3-46CB-9DF8-F5904F307327"), Name = "Berry soap", Price = 30, Description = "You can not eat it!", ImgPath = "Pictures/Berrysoap.jpg" },
                    new Good{Id = Guid.Parse("E1D13CFA-7AB8-49B7-9C4C-4A9E95BA201D"), Name = "Shampoo", Price = 13, Description = "Like washing in the rain!", ImgPath = "Pictures/Shampoo.jpg" },
                    new Good{Id = Guid.Parse("670CE650-1D1B-415A-8E4B-78FC2E4E87EA"), Name = "Pomade", Price = 3, Description = "Animals will love you!", ImgPath = "Pictures/Pomade.jpg" },
                    new Good{Id = Guid.Parse("0CD6235A-51A1-4AFA-BFFB-69B583AE14D2"), Name = "Mineral water", Price = 2, Description = "Cleaner than in Baikal!", ImgPath = "Pictures/Mineralwater.jpg" },
                    new Good{Id = Guid.Parse("BF80BB6A-A346-4B07-9DC2-2B37E0D1F9F6"), Name = "Paper", Price = 7, Description = "Let the trees live!", ImgPath = "Pictures/Paper.jpg" },
                    new Good{Id = Guid.Parse("0EBE8DC9-7395-486B-9E53-3E93B618F81F"), Name = "Perfume", Price = 75, Description = "Animals will look at you indifferently!", ImgPath = "Pictures/Perfume.jpg" },
                    new Good{Id = Guid.Parse("629A8E6E-5F5B-4F94-802C-211039A15667"), Name = "Caviar", Price = 62, Description = "The fish agreed!", ImgPath = "Pictures/Caviar.jpg" },
                    new Good{Id = Guid.Parse("D3E77324-4D98-4000-82F7-C5E91A540BC5"), Name = "Deodorant", Price = 19, Description = "The smell of wood!", ImgPath = "Pictures/Deodorant.jpg" },
                    new Good{Id = Guid.Parse("07680C42-E38E-49E1-9EEF-0ACF654C46A5"), Name = "Wooden utensils", Price = 40, Description = "Carefully! May catch fire!", ImgPath = "Pictures/Woodenutensils.jpg" },
                    new Good{Id = Guid.Parse("05E3D79A-B169-4594-BDDA-828FD7B1143E"), Name = "Rice", Price = 4, Description = "It is very healthy!", ImgPath = "Pictures/Rice.jpg" },
                    new Good{Id = Guid.Parse("F1FC403E-E2C1-4EE2-80B3-400CA7B4FB53"), Name = "Stir sticks", Price = 1, Description = "for a coffee!", ImgPath = "Pictures/Stirsticks.jpg" },
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
