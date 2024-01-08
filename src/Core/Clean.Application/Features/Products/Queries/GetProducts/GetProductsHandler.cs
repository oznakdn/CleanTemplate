using Clean.Application.UnitOfWork.Queries;
using Clean.Domain.Products;
using Clean.Shared;
using Mapster;

namespace Clean.Application.Features.Products.Queries.GetProducts;


public record GetProductsRequest(int MaxPage, int PageSize, int PageNumber, string? query) : IRequest<IResult<GetProductsResponse>>;
public record GetProductsResponse(string Id, string DisplayName, string Currency, decimal Price, string Category, List<ProductImage> Images);
public record ProductImage(string ImageName, string ImageSize);



public class GetProductsHandler : IRequestHandler<GetProductsRequest, IResult<GetProductsResponse>>
{

    private readonly IQueryUnitOfWork _query;

    public GetProductsHandler(IQueryUnitOfWork query)
    {
        _query = query;
    }

    public async Task<IResult<GetProductsResponse>> Handle(GetProductsRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Product> products;

        if (request.MaxPage == 0 || request.PageNumber == 0 || string.IsNullOrEmpty(request.query))
        {
            products = await _query.Product.ReadAllAsync(true);
        }
        else
        {
            products = await _query.Product.ProductSortingAsync(request.MaxPage, request.PageSize, request.PageNumber, request.query, default);
        }

        var config = new TypeAdapterConfig();
        config.NewConfig<Product, GetProductsResponse>()
            .Map(src => src.Id, dest => dest.Id.ToString())
            .Map(src => src.Currency, src => src.Price.Currency.ToString())
            .Map(src => src.Price, dest => dest.Price.Amount)
            .Map(src => src.Category, src => src.Category.DisplayName)
            .Map(src => src.Images, src => src.Images);

        var result = products.Adapt<IEnumerable<GetProductsResponse>>(config);

        if (products is null)
        {
            return Result<GetProductsResponse>.Fail("Product not found!");
        }

        return Result<GetProductsResponse>.Success(values: result);
    }
}
