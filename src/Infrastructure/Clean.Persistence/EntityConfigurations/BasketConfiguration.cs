using Clean.Domain.Baskets;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Persistence.EntityConfigurations;

public class BasketConfiguration : IEntityTypeConfiguration<Basket>
{
    public void Configure(EntityTypeBuilder<Basket> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany<BasketItem>()
               .WithOne(x => x.Basket)
               .HasForeignKey(x => x.BasketId);
    }
}
