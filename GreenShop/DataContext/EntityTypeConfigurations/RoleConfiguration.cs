using GreenShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreenShop.DataContext.EntityTypeConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(role => role.Id);
            builder.HasIndex(role => role.Id).IsUnique();
        }
    }
}
