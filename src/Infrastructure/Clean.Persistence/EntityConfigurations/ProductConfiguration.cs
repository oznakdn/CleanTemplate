using Clean.Domain.Entities.Category;
using Clean.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Persistence.EntityConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne<Category>()
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.CategoryId);
        builder.OwnsOne(x => x.Currency);
        builder.OwnsOne(x => x.Inventory);

    }
}
