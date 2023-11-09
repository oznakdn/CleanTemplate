using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.Products.Repositories;

public interface IProductCommand : IEFCommandRepository<Product,Guid>
{
}
