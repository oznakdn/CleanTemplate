using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.Products.Repositories;

public interface IProductQuery : IEFQueryRepository<Product, Guid>
{
    Task<List<Product>> GetAllProductsWithInventoryAsync(int maxPage, int pageSize, int pageNumber, CancellationToken cancellationToken = default);
    Task<List<Product>> ProductSortingAsync(int maxPage, int pageSize, int pageNumber, string query, CancellationToken cancellationToken = default);

}
