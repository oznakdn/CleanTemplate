using Clean.Application.Results;
using Clean.Application.UnitOfWork.Queries;

namespace Clean.Application.Features.Products.Queries.GetProducts;


public record GetProductsRequest() : IRequest<IDataResult<GetProductsResponse>>;
public record GetProductsResponse(string Id, string DisplayName, string Currency, decimal Price, string Category);



public class GetProductsHandler : IRequestHandler<GetProductsRequest, IDataResult<GetProductsResponse>>
{

    private readonly IQueryUnitOfWork _query;

    public GetProductsHandler(IQueryUnitOfWork query)
    {
        _query = query;
    }

    public async Task<IDataResult<GetProductsResponse>> Handle(GetProductsRequest request, CancellationToken cancellationToken)
    {
        var products = await _query.Product.ReadAllAsync(true, cancellationToken: cancellationToken, includeProperties: x => x.Inventory);

        List<GetProductsResponse> result = products
            .Select(x => new GetProductsResponse
                   (
                     x.Id.ToString(),
                     x.DisplayName,
                     x.Price.Currency.ToString(), 
                     x.Price.Amount,
                     x.Category.DisplayName)).ToList();

        return new DataResult<GetProductsResponse>(result);
    }
}
