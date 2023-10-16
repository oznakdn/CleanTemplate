namespace Clean.Application.Features.Users.Queries.Login;

public class LoginValidator:AbstractValidator<LoginRequest>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().NotNull().Length(6, 10);
    }
}
