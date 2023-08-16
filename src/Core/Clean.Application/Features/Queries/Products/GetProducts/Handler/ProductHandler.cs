namespace Clean.Application.Features.Queries.Products.GetProducts.Handler;

public class ProductHandler : AbstractHandler<ProductRequest, List<ProductResponse>>
{
    private readonly IEFProductRepository _product;
    public ProductHandler(IEFProductRepository product)
    {
        _product = product;
    }

    public async override Task<List<ProductResponse>> Handle(ProductRequest request, CancellationToken cancellationToken)
    {
        var products = await _product.GetAllAsync(null);
        var result = _product._mapper.Map<IEnumerable<ProductResponse>>(products);
        return result.ToList();
    }

   
}
