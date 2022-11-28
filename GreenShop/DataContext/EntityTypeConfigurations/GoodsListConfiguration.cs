using GreenShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreenShop.DataContext.EntityTypeConfigurations
{
    public class GoodsListConfiguration : IEntityTypeConfiguration<GoodsList>
    {
        public void Configure(EntityTypeBuilder<GoodsList> builder)
        {
            builder.HasKey(goodsList => goodsList.Id);
            builder.HasIndex(goodsList => goodsList.Id).IsUnique();
        }
    }
}
