namespace Clean.Application.Features.Commands.RoleCommands.Create.Dtos;

public class CreateRoleRequest : IRequest<CreateRoleResponse>
{
    public string RoleTitle { get; set; }
    public string Description { get; set; }
}
