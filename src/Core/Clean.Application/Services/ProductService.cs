using Clean.Domain.Entities;
using Clean.Persistence.Repositories.Interfaces;

namespace Clean.Application.Services;

public class ProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>>Get()
    {
      return await  _productRepository.GetAllAsync(null);
    }
}
