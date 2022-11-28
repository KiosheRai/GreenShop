using GreenShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreenShop.DataContext.EntityTypeConfigurations
{
    public class GoodConfiguration : IEntityTypeConfiguration<Good>
    {
        public void Configure(EntityTypeBuilder<Good> builder)
        {
            builder.HasKey(good => good.Id);
            builder.HasIndex(good => good.Id).IsUnique();
        }
    }
}
