using Clean.Api.Controllers.Abstract;
using Clean.Application.Features.Queries.ProductQueries.Get.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers;

//[Authorize]
public class ProductsController : AbstractController
{
    public ProductsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<IActionResult>GetProducts(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new ProductRequest(), cancellationToken);
        return Ok(result);
    }
}
