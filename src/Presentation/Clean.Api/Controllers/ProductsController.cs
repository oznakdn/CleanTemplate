using Clean.Api.Controllers.Abstract;
using Clean.Application.Features.Queries.ProductQueries.Get.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers;

public class ProductsController : AbstractController
{
    public ProductsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<IActionResult>GetProducts()
    {
        var result = await _mediator.Send(new ProductRequest());
        return Ok(result);
    }
}
