using Clean.Domain.Entities.Category;
using Clean.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Persistence.EntityConfigurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany<Product>()
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId);
    }
}
