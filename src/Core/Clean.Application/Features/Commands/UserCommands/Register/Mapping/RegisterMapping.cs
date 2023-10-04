using Clean.Application.Features.Commands.UserCommands.Register.Dtos;
using Clean.Domain.Identities.User;

namespace Clean.Application.Features.Commands.UserCommands.Register.Mapping;

public class RegisterMapping : Profile
{
    public RegisterMapping()
    {
        CreateMap<RegisterRequest, AppUser>();
    }
}
