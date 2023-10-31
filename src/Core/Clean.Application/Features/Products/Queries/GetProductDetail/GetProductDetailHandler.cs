using Clean.Application.UnitOfWork.Queries;
using Clean.Domain.Shared;
using Mapster;

namespace Clean.Application.Features.Products.Queries.GetProductDetail;


public record GetProductDetailRequest(string productId) : IRequest<TResult<GetProductDetailResponse>>;
public record GetProductDetailResponse(string Id, string DisplayName, ProductMoney Money, ProductCategory Category, ProductInventory Inventory);
public record ProductMoney(string Currency, decimal Amount);
public record ProductCategory(string DisplayName);
public record ProductInventory(int Quantity, bool HasStock);

public class GetProductDetailHandler : IRequestHandler<GetProductDetailRequest, TResult<GetProductDetailResponse>>
{
    private readonly IQueryUnitOfWork _query;

    public GetProductDetailHandler(IQueryUnitOfWork query)
    {
        _query = query;
    }

    public async Task<TResult<GetProductDetailResponse>> Handle(GetProductDetailRequest request, CancellationToken cancellationToken)
    {
        var product = await _query.Product.ReadSingleOrDefaultAsync(true,
            filter: x => x.Id == Guid.Parse(request.productId),
            cancellationToken: cancellationToken,
            includeProperties: x => x.Inventory);

        if (product is null)
            return TResult<GetProductDetailResponse>.Fail("Product not found!");

        ProductMoney money = product.Price.Adapt<ProductMoney>();
        ProductCategory category = product.Category.Adapt<ProductCategory>();
        ProductInventory inventory = product.Inventory.Adapt<ProductInventory>();

        GetProductDetailResponse response = new(product.Id.ToString(), product.DisplayName, money, category, inventory);

        return TResult<GetProductDetailResponse>.Ok(response);
    }
}
