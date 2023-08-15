using Clean.Application.Features.Abstracts.Handler;
using Clean.Application.Features.Product.Dtos;
using Clean.Persistence.Repositories.Interfaces;

namespace Clean.Application.Features.Product.Handler;

public class ProductHandler : GenericHandler<ProductRequest,ProductResponse>
{
    private readonly IProductRepository _product;
    public ProductHandler(IProductRepository product)
    {
        _product = product;
    }

    public override async Task<ProductResponse> Handle(ProductRequest request, CancellationToken cancellationToken)
    {
        var products = await _product.GetAllAsync(null);
        var productModel = _product._mapper.Map<ProductResponse>(products);
        return new ProductResponse
        {
            Products = productModel.Products
        };

    }
}
