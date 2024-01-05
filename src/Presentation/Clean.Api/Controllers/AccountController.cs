using Clean.Application.Features.Customers.Commands.Create;
using Clean.Application.Features.Customers.Queries.LoginCustomer;

namespace Clean.Api.Controllers;

public class AccountController : AbstractController
{
    public AccountController(IMediator mediator) : base(mediator)
    {
    }


    [HttpPut]
    public async Task<IActionResult> Login([FromBody] LoginCustomerRequest login)
    {
        var result = await _mediator.Send(login);
        if (result.Errors.Count() > 0 && result.IsFailed) return BadRequest(result.Errors);

        if (!string.IsNullOrEmpty(result.Message) && result.IsFailed) return NotFound(result.Message);

        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] CreateCustomerRequest register)
    {
        var result = await _mediator.Send(register);
        if (result.IsFailed)
        {
            return BadRequest(result.Errors);
        }
        return Created(result.Message, register);

    }

}
