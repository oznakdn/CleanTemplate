using Clean.Domain.Contracts.Interfaces;
using Clean.Domain.Products;

namespace Clean.Domain.Repositories
{
    public interface IProductRepository : IEFRepository<Product, Guid>
    {
    }
}
