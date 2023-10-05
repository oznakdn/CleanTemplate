using Clean.Domain.Contracts.Events;
using Clean.Domain.Entities.Product;

namespace Clean.Domain.Events;

public class ProductDeletedDomainEvent : IDomaintEvent
{
    internal ProductDeletedDomainEvent(Product product) => Product = product;

    public Product Product { get; }
}
