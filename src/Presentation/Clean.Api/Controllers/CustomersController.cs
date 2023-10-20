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
    [Authorize]
    public async Task<IActionResult> GetCustomer([FromQuery]string? CustomerId, [FromQuery] string? NameOrSurname)
    {
        var result = await _mediator.Send(new GetCustomerRequest(CustomerId, NameOrSurname));

        if(result.Data != null)
        {
            return Ok(result.Data);
        }
        return Ok(result.Datas);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult>GetCustomers()
    {
        var result = await _mediator.Send(new GetCustomersRequest());
        return Ok(result.Datas);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest createCustomer)
    {
        var result = await _mediator.Send(createCustomer);
        if(result.Successed)
        {
            return Created(result.Message, createCustomer);
        }
        return BadRequest(result.Errors);
    }
   
}