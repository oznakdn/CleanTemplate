using Clean.Application.Features.Commands.Customers.Add.Dtos;
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

    [HttpPost]
    public async Task<IActionResult> PostCustomer([FromBody]AddCustomerRequest addCustomer)
    {
        var result = await _mediator.Send(addCustomer);
        if(result.Success)
            return Ok(result);
        return BadRequest(result.Messages);
    }
}