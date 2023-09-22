namespace Clean.Application.Features.Queries.Products.GetProducts.Handler;

public class ProductHandler : IRequestHandler<ProductRequest, List<ProductResponse>>
{
    private readonly IEfUnitOfWork _efUnitOfWork;
    public ProductHandler(IEfUnitOfWork efUnitOfWork)
    {
        _efUnitOfWork = efUnitOfWork;
    }

    public async Task<List<ProductResponse>> Handle(ProductRequest request, CancellationToken cancellationToken)
    {
        var products = await _efUnitOfWork.Product.GetAllAsync(null);
        var result = _efUnitOfWork.Mapper.Map<IEnumerable<ProductResponse>>(products);
        return result.ToList();
    }
}
