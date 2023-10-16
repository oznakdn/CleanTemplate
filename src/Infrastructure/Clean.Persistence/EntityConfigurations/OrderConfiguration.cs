using Clean.Domain.Orders;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Persistence.EntityConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany<OrderItem>()
               .WithOne(x => x.Order)
               .HasForeignKey(x => x.OrderId);
    }
}
