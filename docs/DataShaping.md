# DATA SHAPING

## Shaper Service
```csharp
public interface IDataShaper<T>
{
    IEnumerable<ExpandoObject> ShapeDatas(IEnumerable<T> entities, string fieldsString);
    ExpandoObject ShapeData(T entity, string fieldsString);
}
```

```csharp
public class DataShaper<T>:IDataShaper<T>
{
    public PropertyInfo[] Properties { get; set; }
    public DataShaper()
    {
        Properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
    }

    public IEnumerable<ExpandoObject> ShapeDatas(IEnumerable<T> entities, string fieldsString)
    {
        var requiredProperties = GetRequiredProperties(fieldsString);
        return FetchData(entities, requiredProperties);
    }

    public ExpandoObject ShapeData(T entity, string fieldsString)
    {
        var requiredProperties = GetRequiredProperties(fieldsString);
        return FetchDataForEntity(entity, requiredProperties);
    }

    private IEnumerable<PropertyInfo> GetRequiredProperties(string fieldsString)
    {
        var requiredProperties = new List<PropertyInfo>();
        if (!string.IsNullOrWhiteSpace(fieldsString))
        {
            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);
            foreach (var field in fields)
            {
                var property = Properties.FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));
                if (property == null)
                    continue;
                requiredProperties.Add(property);
            }
        }
        else
        {
            requiredProperties = Properties.ToList();
        }
        return requiredProperties;
    }

    private IEnumerable<ExpandoObject> FetchData(IEnumerable<T> entities, IEnumerable<PropertyInfo> requiredProperties)
    {
        var shapedData = new List<ExpandoObject>();
        foreach (var entity in entities)
        {
            var shapedObject = FetchDataForEntity(entity, requiredProperties);
            shapedData.Add(shapedObject);
        }
        return shapedData;
    }


    private ExpandoObject FetchDataForEntity(T entity, IEnumerable<PropertyInfo> requiredProperties)
    {
        var shapedObject = new ExpandoObject();
        foreach (var property in requiredProperties)
        {
            var objectPropertyValue = property.GetValue(entity);
            shapedObject.TryAdd(property.Name, objectPropertyValue);
        }
        return shapedObject;
    }


}
```
## IOC Container Registration
```csharp
services.AddScoped(typeof(IDataShaper<>), typeof(DataShaper<>));
```

## Handler

```csharp
public record GetProductsDataShapingRequest(string fields) : IRequest<TResult<ExpandoObject>>;
public record GetProductsDataShapingResponse(string Id, string DisplayName, string Currency, decimal Price, string Category);
```

```csharp
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
```
## Controller
```csharp
public class ProductsController : AbstractController
{
    public ProductsController(IMediator mediator) : base(mediator){}

    [HttpGet]
    public async Task<IActionResult> GetProductsWithDataShaping([FromQuery]string fields)
    {
        var result = await _mediator.Send(new GetProductsDataShapingRequest(fields));
        return Ok(result.Values);
    }

}
```

![DataShaping1](https://github.com/oznakdn/CleanTemplate/assets/79724084/9196c29e-f78d-436c-927f-57beb2bf15b9)

![DataShaping2](https://github.com/oznakdn/CleanTemplate/assets/79724084/58fda627-cfe8-4c7f-b565-0fa0481c7912)


