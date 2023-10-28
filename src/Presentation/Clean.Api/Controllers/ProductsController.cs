using Clean.Application.Features.Products.Commands.Create;
using Clean.Application.Features.Products.Queries.GetProductDetail;
using Clean.Application.Features.Products.Queries.GetProducts;
using Clean.Persistence.Caching;
using Microsoft.AspNetCore.RateLimiting;

namespace Clean.Api.Controllers;


public class ProductsController : AbstractController
{
    private readonly IProductCacheService _productCache;

    public ProductsController(IMediator mediator, IProductCacheService productCache) : base(mediator)
    {
        _productCache = productCache;
    }



    [HttpGet]
    [EnableRateLimiting("Api")]
    public async Task<IActionResult> GetProducts()
    {
        var result = await _mediator.Send(new GetProductsRequest());
        return Ok(result.Datas);
    }


    [HttpGet]
    public IActionResult GetProductsCache()
    {
        var result = _productCache.GetProductFromCache();
        return Ok(result);
    }


    [HttpGet("{productId}")]
    public async Task<IActionResult> GetProductDetail(string productId)
    {
        var result = await _mediator.Send(new GetProductDetailRequest(productId));
        if(!result.IsSuccessed) return NotFound(result.Message);
        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest createProduct)
    {
        var result = await _mediator.Send(createProduct);
        if (!result.IsSuccessed && result.Messages.Count > 0)
        {
            return BadRequest(result.Messages);
        }

        return Ok(result.Message);
    }

}
