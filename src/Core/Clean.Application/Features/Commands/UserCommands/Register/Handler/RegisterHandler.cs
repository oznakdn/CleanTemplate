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
        var response = new RegisterResponse();

        var validator = new RegisterValidator();
        var validation = validator.Validate(request);

        if(validation.IsValid)
        {
            var existUser = await _efUnitOfWork.User.GetAsync(cancellationToken, user => user.Email == request.Email);
            if (existUser != null)
            {
                response.Success = false;
                response.Message = "You cannot use this email!";
                return response;
            }

            request.PasswordHash = request.PasswordHash.HashPassword();
            _efUnitOfWork.User.Insert(_efUnitOfWork.Mapper.Map<AppUser>(request));
            await _efUnitOfWork.SaveAsync();
            response.Message = $"{request.Email} user was be register.";
            response.Success = true;
            return response;
        }
        var errors = new List<string>();
        validation.Errors.ForEach(e => errors.Add(e.ErrorMessage));
        response.Success = false;
        response.Errors = errors;
        return response;
    }
}
