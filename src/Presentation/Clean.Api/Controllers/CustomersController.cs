using Clean.Api.Controllers.Abstract;
using Clean.Application.Features.Customers.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers;


public class CustomersController : AbstractController
{
    public CustomersController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
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