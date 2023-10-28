using Clean.Application.Results;
using Clean.Application.UnitOfWork.Queries;
using Mapster;

namespace Clean.Application.Features.Products.Queries.GetProductDetail;


public record GetProductDetailRequest(string productId) : IRequest<IDataResult<GetProductDetailResponse>>;
public record GetProductDetailResponse(string Id, string DisplayName, ProductMoney Money, ProductCategory Category, ProductInventory Inventory);
public record ProductMoney(string Currency, decimal Amount);
public record ProductCategory(string DisplayName);
public record ProductInventory(int Quantity, bool HasStock);

public class GetProductDetailHandler : IRequestHandler<GetProductDetailRequest, IDataResult<GetProductDetailResponse>>
{
    private readonly IQueryUnitOfWork _query;

    public GetProductDetailHandler(IQueryUnitOfWork query)
    {
        _query = query;
    }

    public async Task<IDataResult<GetProductDetailResponse>> Handle(GetProductDetailRequest request, CancellationToken cancellationToken)
    {
        var product = await _query.Product.ReadSingleOrDefaultAsync(true,
            filter: x => x.Id == Guid.Parse(request.productId),
            cancellationToken: cancellationToken,
            includeProperties: x => x.Inventory);

        if (product is null)
            return new DataResult<GetProductDetailResponse>("Product not found!",false);

        ProductMoney money = product.Price.Adapt<ProductMoney>();
        ProductCategory category = product.Category.Adapt<ProductCategory>();
        ProductInventory inventory = product.Inventory.Adapt<ProductInventory>();

        GetProductDetailResponse response = new(product.Id.ToString(), product.DisplayName, money, category, inventory);

        return new DataResult<GetProductDetailResponse>(response);
    }
}
