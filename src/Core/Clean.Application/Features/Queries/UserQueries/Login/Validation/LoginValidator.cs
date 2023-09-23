using Clean.Application.Features.Queries.UserQueries.Login.Dtos;

namespace Clean.Application.Features.Queries.UserQueries.Login.Validation;

internal class LoginValidator : AbstractValidator<LoginRequest>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email).NotEmpty().NotNull();
        RuleFor(x => x.Password).NotEmpty().NotNull();
    }
}
