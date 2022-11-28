using GreenShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreenShop.DataContext.EntityTypeConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(order => order.Id);
            builder.HasIndex(order => order.Id).IsUnique();
        }
    }
}
