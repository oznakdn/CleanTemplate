using Clean.Application.Features.Queries.Products.GetProducts.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult>GetProducts()
    {
        var result = await _mediator.Send(new ProductRequest());
        return Ok(result);
    }
}
