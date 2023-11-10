using Clean.Application.DataShaping;
using Clean.Application.UnitOfWork.Queries;
using Clean.Domain.Products;
using Clean.Domain.Shared;
using Mapster;
using System.Dynamic;

namespace Clean.Application.Features.Products.Queries.GetProductsWithDataShaping;

public record GetProductsDataShapingRequest(string fields) : IRequest<TResult<ExpandoObject>>;
public record GetProductsDataShapingResponse(string Id, string DisplayName, string Currency, decimal Price, string Category);


public class GetProductsWithDataShapingHandler : IRequestHandler<GetProductsDataShapingRequest, TResult<ExpandoObject>>
{
    private readonly IQueryUnitOfWork _query;
    private readonly IDataShaper<GetProductsDataShapingResponse> _shaper;
    public GetProductsWithDataShapingHandler(IQueryUnitOfWork query, IDataShaper<GetProductsDataShapingResponse> shaper)
    {
        _query = query;
        _shaper = shaper;
    }

    public async Task<TResult<ExpandoObject>> Handle(GetProductsDataShapingRequest request, CancellationToken cancellationToken)
    {
        var products = await _query.Product.ReadAllAsync(noTracking:true,cancellationToken:default);

        var config = new TypeAdapterConfig();
        config.NewConfig<Product, GetProductsDataShapingResponse>()
            .Map(src => src.Id, dest => dest.Id.ToString())
            .Map(src => src.Currency, src => src.Price.Currency.ToString())
            .Map(src => src.Price, dest => dest.Price.Amount)
            .Map(src => src.Category, src => src.Category.DisplayName);

        var result = products.Adapt<IEnumerable<GetProductsDataShapingResponse>>(config);

        IEnumerable<ExpandoObject> shapedDatas = _shaper.ShapeDatas(result,request.fields);

        return TResult<ExpandoObject>.Ok(shapedDatas);

    }
}
