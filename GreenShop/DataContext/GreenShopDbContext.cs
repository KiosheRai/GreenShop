using GreenShop.DataContext.EntityTypeConfigurations;
using GreenShop.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GreenShop.DataContext
{
    public class GreenShopDbContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Good> Good { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<GoodsList> GoodsLists { get; set; }

        public GreenShopDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost;Database=GreenShop;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryConfiguration());
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

            base.OnModelCreating(builder);
        }
    }
}
