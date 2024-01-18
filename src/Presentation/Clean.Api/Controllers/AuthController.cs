using Clean.Application.Features.Roles.Commands.AssignRole;
using Clean.Application.Features.Roles.Commands.Create;
using Clean.Application.Features.Roles.Queries.GetRoles;
using Clean.Application.Features.Users.Commands.Register;
using Clean.Application.Features.Users.Queries.Login;

namespace Clean.Api.Controllers;

[Route("api/auths")]
public class AuthController : AbstractController
{

    public AuthController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPut("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest login)
    {
        var result = await _mediator.Send(login);
        if (result.Errors.Count() > 0 && !result.IsSuccess) return BadRequest(result.Errors);

        if (!string.IsNullOrEmpty(result.Message) && !result.IsSuccess) return NotFound(result.Message);

        return Ok(result.Value);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest register)
    {
        var result = await _mediator.Send(register);

        if (!result.IsSuccess)
        {
            return result.Errors.Count() == 0 ? BadRequest(result.Error) : BadRequest(result.Errors);
        }
        return Ok(result.Message);

    }

    [HttpPost("create-role")]
    public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest createRole)
    {
        var result = await _mediator.Send(createRole);

        if (!result.IsSuccess) return BadRequest(result.Errors);

        return Created(result.Message, createRole);
    }

    [HttpGet("get-roles")]
    public async Task<IActionResult> GetRoles()
    {
        var result = await _mediator.Send(new GetRolesRequest());
        return Ok(result.Values);
    }

    [HttpPut("assign-role")]
    public async Task<IActionResult> AssignRole([FromBody] AssignRoleRequest assignRole)
    {
        var result = await _mediator.Send(assignRole, default);
        return !result.IsSuccess ? NotFound(result.Message) : Ok(result.Message);
    }
}
