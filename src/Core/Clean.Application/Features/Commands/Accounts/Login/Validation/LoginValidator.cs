namespace Clean.Application.Features.Commands.Accounts.Login.Validation;

internal class LoginValidator:AbstractValidator<LoginRequest>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email).NotEmpty().NotNull();
        RuleFor(x=> x.Password).NotEmpty().NotNull();
    }
}
