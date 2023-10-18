using Clean.Application.Results;
using Clean.Domain.Repositories;

namespace Clean.Application.Features.Products.Queries.GetProducts;


public record GetProductsRequest() : IRequest<IDataResult<GetProductsResponse>>;
public record GetProductsResponse(string Id, string DisplayName, ProductMoney Money, ProductCategory Category, ProductInventory Inventory);
public record ProductMoney(string Currency, decimal Price);
public record ProductCategory(string DisplayName);
public record ProductInventory(int Quantity, bool HasStock);




public class GetProductsHandler : IRequestHandler<GetProductsRequest, IDataResult<GetProductsResponse>>
{

    private readonly IProductRepository _product;

    public GetProductsHandler(IProductRepository product)
    {
        _product = product;
    }

    public async Task<IDataResult<GetProductsResponse>> Handle(GetProductsRequest request, CancellationToken cancellationToken)
    {
        var products = await _product.GetAllAsync(cancellationToken, null, x => x.Inventory);

        List<GetProductsResponse> result = products
            .Select(x => new GetProductsResponse
                   (
                     x.Id.ToString(),
                     x.DisplayName,
                     new ProductMoney(x.Price.Currency.ToString(), x.Price.Amount),
                     new ProductCategory(x.Category.DisplayName),
                     new ProductInventory(x.Inventory.Quantity, x.Inventory.HasStock)
                    )).ToList();

        return new DataResult<GetProductsResponse>(result);
    }
}
