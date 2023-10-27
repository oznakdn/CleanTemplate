using Clean.Application.Results;
using Clean.Application.UnitOfWork.Queries;
using Clean.Domain.Customers;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Clean.Application.Features.Customers.Queries.GetCustomer;

public record GetCustomerRequest(string? CustomerId, string? Name) : IRequest<IDataResult<GetCustomerResponse>>;
public record GetCustomerResponse(string FirstName, string LastName, string Email, string PhoneNumber);


public class GetCustomerHandler : IRequestHandler<GetCustomerRequest, IDataResult<GetCustomerResponse>>
{
    private readonly IQueryUnitOfWork _query;

    public GetCustomerHandler(IQueryUnitOfWork query)
    {
        _query = query;
    }

    public async Task<IDataResult<GetCustomerResponse>> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
    {
        var query = await _query.Customer.QueryAsync(true, cancellationToken: cancellationToken);

        if (!string.IsNullOrEmpty(request.CustomerId))
        {
            Customer customer = await query.Where(x => x.Id == Guid.Parse(request.CustomerId)).SingleOrDefaultAsync(cancellationToken);

            if(customer is null)
            {
                return new DataResult<GetCustomerResponse>("Customer not found!",false);
            }

            GetCustomerResponse result = query.Adapt<GetCustomerResponse>();
            return new DataResult<GetCustomerResponse>(result);
        }

        if (!string.IsNullOrEmpty(request.Name))
        {
            var customer = await query
                .Where(x => x.FirstName.ToLower().Contains(request.Name.ToLower()) || x.LastName.ToLower().Contains(request.Name.ToLower()))
                .ToListAsync(cancellationToken);

            if (customer.Count == 0)
            {
                return new DataResult<GetCustomerResponse>("Customer not found!",false);
            }

            IEnumerable<GetCustomerResponse> result = customer.Adapt<IEnumerable<GetCustomerResponse>>();
            return new DataResult<GetCustomerResponse>(result.ToList());
        }

        var customers = await query.ToListAsync();
        IEnumerable<GetCustomerResponse> response = customers.Adapt<IEnumerable<GetCustomerResponse>>();
        return new DataResult<GetCustomerResponse>(response.ToList());

    }
}
