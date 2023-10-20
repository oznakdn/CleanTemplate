using Clean.Application.Features.Users.Commands.Register;
using Clean.Application.Features.Users.Queries.Login;

namespace Clean.Api.Controllers;

public class AccountController : AbstractController
{
    public AccountController(IMediator mediator) : base(mediator)
    {
    }


    [HttpPut]
    public async Task<IActionResult> Login([FromBody] LoginRequest login)
    {
        var result = await _mediator.Send(login);
        if (result.Errors.Count > 0 && !result.Successed) return BadRequest(result.Errors);
        if (!string.IsNullOrEmpty(result.Message) && !result.Successed) return NotFound(result.Message);
        return Ok(new
        {
            Access = result.AccessToken,
            AccessExpires = result.AccessExpire,
            Refresh = result.RefreshToken,
            RefreshExpires = result.RefreshExpire
        });
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterRequest register)
    {
        var result = await _mediator.Send(register);
        if (!result.Successed)
        {
            return BadRequest(result.Errors);
        }
        return Created(result.message!, register);

    }


}
