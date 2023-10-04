using Clean.Application.Features.Commands.RoleCommands.Create.Dtos;
using Clean.Domain.Identities.Role;

namespace Clean.Application.Features.Commands.RoleCommands.Create.Mapping;

public class CreateRoleMapping : Profile
{
    public CreateRoleMapping()
    {
        CreateMap<CreateRoleRequest, AppRole>();
    }
}
