using Clean.Application.UnitOfWork.Queries;
using Clean.Domain.Products;
using Clean.Domain.Shared;
using Mapster;

namespace Clean.Application.Features.Products.Queries.GetProducts;


public record GetProductsRequest(int MaxPage, int PageSize, int PageNumber) : IRequest<TResult<GetProductsResponse>>;
public record GetProductsResponse(string Id, string DisplayName, string Currency, decimal Price, string Category);



public class GetProductsHandler : IRequestHandler<GetProductsRequest, TResult<GetProductsResponse>>
{

    private readonly IQueryUnitOfWork _query;

    public GetProductsHandler(IQueryUnitOfWork query)
    {
        _query = query;
    }

    public async Task<TResult<GetProductsResponse>> Handle(GetProductsRequest request, CancellationToken cancellationToken)
    {
        var products = await _query.Product.GetAllProductsWithInventoryAsync(request.MaxPage,request.PageSize,request.PageNumber,default);

        var config = new TypeAdapterConfig();
        config.NewConfig<Product, GetProductsResponse>()
            .Map(src => src.Id, dest => dest.Id.ToString())
            .Map(src => src.Currency, src => src.Price.Currency.ToString())
            .Map(src => src.Price, dest => dest.Price.Amount)
            .Map(src => src.Category, src => src.Category.DisplayName);

        var result = products.Adapt<IEnumerable<GetProductsResponse>>(config);

        if(products is null)
        {
            return TResult<GetProductsResponse>.Fail("Product not found!");
        }

        return TResult<GetProductsResponse>.Ok(result);
    }
}
