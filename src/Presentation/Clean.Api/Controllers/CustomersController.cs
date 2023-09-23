using Clean.Api.Controllers.Abstract;
using Clean.Application.Features.Commands.CustomerCommands.Create.Dtos;
using Clean.Application.Features.Queries.CustomerQueries.Get.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers;


public class CustomersController:AbstractController
{
    public CustomersController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<IActionResult>GetCustomers()
    {
        var result = await _mediator.Send(new GetCustomersRequest());
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> PostCustomer([FromBody]CreateCustomerRequest createCustomer)
    {
        var result = await _mediator.Send(createCustomer);
        if(result.Success)
            return Ok(result);
        return BadRequest(result.Messages);
    }
}