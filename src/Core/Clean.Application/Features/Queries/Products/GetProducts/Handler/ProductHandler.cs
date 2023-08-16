using Clean.Application.Features.Queries.Products.GetProducts.Dtos;

namespace Clean.Application.Features.Queries.Products.GetProducts.Handler;

public class ProductHandler : GenericHandler<ProductRequest, ProductResponse>
{
    private readonly IEFProductRepository _product;
    public ProductHandler(IEFProductRepository product)
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
