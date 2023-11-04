using Clean.Application.Features.Baskets.Queries.GetCustomerBasket;
using Clean.Application.Features.Customers.Commands.Create;
using Clean.Application.Features.Customers.Queries.GetCustomer;
using Clean.Application.Features.Customers.Queries.GetCustomers;
using Microsoft.AspNetCore.Authorization;

namespace Clean.Api.Controllers;


public class CustomersController : AbstractController
{
    public CustomersController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetCustomer([FromQuery] string? CustomerId, [FromQuery] string? NameOrSurname)
    {
        var result = await _mediator.Send(new GetCustomerRequest(CustomerId, NameOrSurname));

        if (result.IsFailed)
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

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest createCustomer)
    {
        var result = await _mediator.Send(createCustomer);
        if (result.IsSuccessed)
        {
            return Created(result.Message, createCustomer);
        }
        return BadRequest(result.Errors);
    }


    [HttpGet("{CustomerId}")]
    public async Task<IActionResult> GetCustomerBasket(string CustomerId)
    {
        var result = await _mediator.Send(new GetCustomerBasketRequest(CustomerId));
        if (result.IsSuccessed)
            return Ok(result);

        return NotFound(result.Message);
    }

}