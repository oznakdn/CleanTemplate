using Clean.Application.Features.Queries.Customers.GetCustomers.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController:ControllerBase
{
    private readonly IMediator _mediator;

    public CustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult>GetCustomers()
    {
        var result = await _mediator.Send(new GetCustomersRequest());
        return Ok(result);
    }
}