using Clean.Application.Results;
using Clean.Application.UnitOfWork.Queries;

namespace Clean.Application.Features.Customers.Queries.GetCustomers;


public record GetCustomersRequest : IRequest<IDataResult<GetCustomersResponse>>;
public record GetCustomersResponse(string Id, string FirstName, string LastName, string Email, string PhoneNumber);

public class GetCustomersHandler : IRequestHandler<GetCustomersRequest, IDataResult<GetCustomersResponse>>
{
    private readonly IQueryUnitOfWork _query;

    public GetCustomersHandler(IQueryUnitOfWork query)
    {
        _query = query;
    }

    public async Task<IDataResult<GetCustomersResponse>> Handle(GetCustomersRequest request, CancellationToken cancellationToken)
    {
        var customers = await _query.Customer.ReadAllAsync(true, cancellationToken: cancellationToken);

        List<GetCustomersResponse> customersDto = customers
            .Select(x => new GetCustomersResponse(x.Id.ToString(), x.FirstName, x.LastName, x.Email, x.PhoneNumber))
            .ToList();

        return new DataResult<GetCustomersResponse>(customersDto);
    }
}
