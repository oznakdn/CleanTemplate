using Clean.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Persistence.EntityConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.OwnsOne(p => p.Inventory);
        builder.OwnsOne(p => p.Currency);
    }
}
