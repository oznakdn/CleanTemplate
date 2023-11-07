## Rate Limiting
### Program.cs
```csharp
builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("Api", options =>
    {
        options.AutoReplenishment = true;
        options.PermitLimit = 10;
        options.Window = TimeSpan.FromMinutes(1);
    });

    options.AddFixedWindowLimiter("Web", options =>
    {
        options.AutoReplenishment = true;
        options.PermitLimit = 20;
        options.Window = TimeSpan.FromMinutes(1);
    });
});
```
```csharp
app.UseRateLimiter();
```
### Controller
```csharp
public class ProductsController : AbstractController
{
    public ProductsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [EnableRateLimiting("Api")]
    public async Task<IActionResult>GetProducts()
    {
        var result = await _mediator.Send(new GetProductsRequest());
        return Ok(result.Datas);
    }
}

```
