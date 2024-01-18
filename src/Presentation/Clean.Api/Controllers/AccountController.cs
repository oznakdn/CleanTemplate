using Clean.Application.Features.Customers.Commands.Create;
using Clean.Application.Features.Customers.Queries.LoginCustomer;

namespace Clean.Api.Controllers;


[Route("api/accounts")]
public class AccountController : AbstractController
{
    public AccountController(IMediator mediator) : base(mediator)
    {
    }


    [HttpPut("login")]
    public async Task<IActionResult> Login([FromBody] LoginCustomerRequest login)
    {
        var result = await _mediator.Send(login);
        if (result.Errors.Count() > 0 && !result.IsSuccess) return BadRequest(result.Errors);

        if (!string.IsNullOrEmpty(result.Message) && !result.IsSuccess) return NotFound(result.Message);

        return Ok(result.Value);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateCustomerRequest register)
    {
        var result = await _mediator.Send(register);
        if (!result.IsSuccess)
        {
            return BadRequest(result.Errors);
        }
        return Created(result.Message, register);

    }

}
