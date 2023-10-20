using Clean.Application.Features.Products.Commands.Create;
using Clean.Application.Features.Products.Queries.GetProducts;
using Microsoft.AspNetCore.Authorization;

namespace Clean.Api.Controllers;

//[Authorize]
public class ProductsController : AbstractController
{
    public ProductsController(IMediator mediator) : base(mediator)
    {
    }


    [HttpGet]
    public async Task<IActionResult>GetProducts()
    {
        var result = await _mediator.Send(new GetProductsRequest());
        return Ok(result.Datas);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody]CreateProductRequest createProduct)
    {
        var result = await _mediator.Send(createProduct);
        return Ok(result.Message);
    }
    
}
