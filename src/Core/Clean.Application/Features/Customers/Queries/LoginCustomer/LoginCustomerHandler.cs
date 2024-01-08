using Clean.Application.UnitOfWork.Queries;
using Clean.Identity.Helpers;
using Clean.Shared;
using Gleeman.JwtGenerator;
using Gleeman.JwtGenerator.Generator;

namespace Clean.Application.Features.Customers.Queries.LoginCustomer;


public record LoginCustomerRequest(string Email, string Password) : IRequest<IResult<LoginCustomerResponse>>;
public record LoginCustomerResponse(string AccessToken, string AccessExpire, string Email);

public class LoginCustomerHandler : IRequestHandler<LoginCustomerRequest, IResult<LoginCustomerResponse>>
{
    private readonly IQueryUnitOfWork _query;
    private readonly ITokenGenerator _token;

    public LoginCustomerHandler(IQueryUnitOfWork query, ITokenGenerator token)
    {
        _query = query;
        _token = token;
    }

    public async Task<IResult<LoginCustomerResponse>> Handle(LoginCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer = await _query.Customer.ReadSingleOrDefaultAsync(true, x => x.Email == request.Email);
        if (customer is null)
        {
            return Result<LoginCustomerResponse>.Fail("customer not found!");
        }

        bool passwordIsValid = request.Password.VerifyHashPassword(customer.Password);

        if (!passwordIsValid)
        {
            return Result<LoginCustomerResponse>.Fail("Password is wrong!");
        }

        var userParameter = new UserParameter
        {
            Id = customer.Id.ToString(),
            Email = customer.Email,
        };

        TokenResult access = _token.GenerateAccessToken(userParameter, ExpireType.Day, 5);

        var response = new LoginCustomerResponse(
            access.Token,
            access.ExpireDate.ToString(),
            customer.Email);

        return Result<LoginCustomerResponse>.Success(value: response);

    }
}
