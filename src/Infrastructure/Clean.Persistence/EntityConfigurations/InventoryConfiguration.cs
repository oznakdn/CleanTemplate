using Clean.Domain.Products;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Persistence.EntityConfigurations;

public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
