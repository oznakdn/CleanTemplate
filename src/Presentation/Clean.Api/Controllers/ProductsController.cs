using Clean.Api.Controllers.Abstract;
using Clean.Application.Features.Products.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers;

//[Authorize]
public class ProductsController : AbstractController
{
    public ProductsController(IMediator mediator) : base(mediator)
    {
    }


    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody]CreateProductRequest createProduct)
    {
        var result = await _mediator.Send(createProduct);
        return Ok(result.Message);
    }
    
}
