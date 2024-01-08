using Clean.Application.UnitOfWork.Queries;
using Clean.Domain.Customers;
using Clean.Shared;
using Mapster;

namespace Clean.Application.Features.Customers.Queries.GetCustomers;


public record GetCustomersRequest() : IRequest<IResult<GetCustomersResponse>>;
public record GetCustomersResponse(string Id, string FirstName, string LastName, string Email, string PhoneNumber);

public class GetCustomersHandler : IRequestHandler<GetCustomersRequest, IResult<GetCustomersResponse>>
{
    private readonly IQueryUnitOfWork _query;
    public GetCustomersHandler(IQueryUnitOfWork query)
    {
        _query = query;
    }

    public async Task<IResult<GetCustomersResponse>> Handle(GetCustomersRequest request, CancellationToken cancellationToken)
    {

        var customers = await _query.Customer.GetCustomersAsync(cancellationToken);

        var config = new TypeAdapterConfig();

        config.NewConfig<Customer, GetCustomersResponse>()
            .Map(dest => dest.Id, src => src.Id.ToString());

        IEnumerable<GetCustomersResponse> response = customers.Adapt<IEnumerable<GetCustomersResponse>>(config);

        return Result<GetCustomersResponse>.Success(values:response.ToList());
    }
}
