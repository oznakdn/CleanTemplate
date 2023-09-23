using Clean.Application.Features.Commands.UserCommands.Register.Dtos;
using Clean.Application.Features.Commands.UserCommands.Register.Validation;
using Clean.Domain.Identities.SQL;

namespace Clean.Application.Features.Commands.UserCommands.Register.Handler;

public class RegisterHandler : IRequestHandler<RegisterRequest, RegisterResponse>
{
    private readonly IEfUnitOfWork _efUnitOfWork;
    public RegisterHandler(IEfUnitOfWork efUnitOfWork)
    {
        _efUnitOfWork = efUnitOfWork;
    }

    // TODO: Mail ile üyelik onayı kodu gönderilecek. Kod random olarak oluşturulacak.
    public async Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        var validator = new RegisterValidator();
        var validation = validator.Validate(request);
        var errors = new List<string>();
        if(validation.IsValid)
        {
            request.PasswordHash = request.PasswordHash.HashPassword();
            _efUnitOfWork.User.Insert(_efUnitOfWork.Mapper.Map<AppUser>(request));
            await _efUnitOfWork.SaveAsync();
            return new RegisterResponse
            {
                Message = $"{request.Email} user was be register."
            };
        }

        validation.Errors.ForEach(e => errors.Add(e.ErrorMessage));
        return new RegisterResponse
        {
            Message = string.Empty,
            Errors = errors
        };

    }
}
