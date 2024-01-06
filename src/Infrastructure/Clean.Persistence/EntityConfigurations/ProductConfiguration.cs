using Clean.Domain.Products;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Persistence.EntityConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);
        builder.OwnsOne(x => x.Category);
        builder.OwnsOne(x => x.Price);
        builder.OwnsMany(x => x.Images);
    }
}
