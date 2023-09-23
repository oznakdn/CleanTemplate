using Clean.Application.Features.Commands.UserCommands.Register.Dtos;
using Clean.Domain.Identities.SQL;

namespace Clean.Application.Features.Commands.UserCommands.Register.Mapping;

public class RegisterMapping : Profile
{
    public RegisterMapping()
    {
        CreateMap<RegisterRequest, AppUser>();
    }
}
