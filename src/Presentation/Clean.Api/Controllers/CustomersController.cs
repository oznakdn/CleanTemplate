using Clean.Application.Features.Baskets.Queries.GetCustomerBasket;
using Clean.Application.Features.Customers.Commands.Create;
using Clean.Application.Features.Customers.Queries.GetCustomer;
using Clean.Application.Features.Customers.Queries.GetCustomers;
using Microsoft.AspNetCore.Authorization;

namespace Clean.Api.Controllers;

[Route("api/customers")]
public class CustomersController : AbstractController
{
    public CustomersController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("customer")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetCustomer([FromQuery] string? CustomerId, [FromQuery] string? NameOrSurname)
    {
        var result = await _mediator.Send(new GetCustomerRequest(CustomerId, NameOrSurname));

        if (!result.IsSuccess)
        {
            return NotFound(result.Message);
        }

        if (result.Value != null)
        {
            return Ok(result.Value);
        }
        return Ok(result.Values);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetCustomers()
    {
        var result = await _mediator.Send(new GetCustomersRequest());
        return Ok(result.Values);
    }

   
    [HttpGet("get-customer-basket/{CustomerId}")]
    public async Task<IActionResult> GetCustomerBasket(string CustomerId)
    {
        var result = await _mediator.Send(new GetCustomerBasketRequest(CustomerId));
        if (result.IsSuccess)
            return Ok(result);

        return NotFound(result.Message);
    }

}