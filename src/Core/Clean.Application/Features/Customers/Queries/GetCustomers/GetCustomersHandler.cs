using Clean.Application.UnitOfWork.Queries;
using Clean.Domain.Customers;
using Clean.Domain.Shared;
using Mapster;

namespace Clean.Application.Features.Customers.Queries.GetCustomers;


public record GetCustomersRequest(int MaxPage, int PageSize, int PageNumber) : IRequest<TResult<GetCustomersResponse>>;
public record GetCustomersResponse(string Id, string FirstName, string LastName, string Email, string PhoneNumber);

public class GetCustomersHandler : IRequestHandler<GetCustomersRequest, TResult<GetCustomersResponse>>
{
    private readonly IQueryUnitOfWork _query;
    public GetCustomersHandler(IQueryUnitOfWork query)
    {
        _query = query;
    }

    public async Task<TResult<GetCustomersResponse>> Handle(GetCustomersRequest request, CancellationToken cancellationToken)
    {

        var customers = await _query.Customer.ReadAllAsync(true, pagination: page =>
        {
            page.MaxPageSize = request.MaxPage;
            page.PageSize = request.PageSize;
            page.PageNumber = request.PageNumber;
        }, cancellationToken: cancellationToken);

        var config = new TypeAdapterConfig();

        config.NewConfig<Customer, GetCustomersResponse>()
            .Map(dest => dest.Id, src => src.Id.ToString());

        IEnumerable<GetCustomersResponse> response = customers.Adapt<IEnumerable<GetCustomersResponse>>(config);

        return TResult<GetCustomersResponse>.Ok(response.ToList());
    }
}
