
using Clean.Application.Features.Roles.Commands.AssignRole;
using Clean.Application.Features.Roles.Commands.Create;
using Clean.Application.Features.Roles.Queries.GetRoles;

namespace Clean.Api.Controllers;


public class AuthController : AbstractController
{
    public AuthController(IMediator mediator) : base(mediator)
    {
    }


    [HttpPost]
    public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest createRole)
    {
        var result = await _mediator.Send(createRole);

        if (result.IsFailed) return BadRequest(result.Errors);

        return Created(result.Message, createRole);
    }

    [HttpGet]
    public async Task<IActionResult> GetRoles()
    {
        var result = await _mediator.Send(new GetRolesRequest());
        return Ok(result.Values);
    }

    [HttpPut]
    public async Task<IActionResult> AssignRole([FromBody] AssignRoleRequest assignRole)
    {
        var result = await _mediator.Send(assignRole, default);
        return result.IsFailed ? NotFound(result.Message) : Ok(result.Message);
    }
}
