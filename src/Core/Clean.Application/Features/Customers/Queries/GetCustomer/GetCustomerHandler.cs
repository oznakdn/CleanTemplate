using Clean.Application.UnitOfWork.Queries;
using Clean.Domain.Customers;
using Clean.Shared;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Clean.Application.Features.Customers.Queries.GetCustomer;

public record GetCustomerRequest(string? CustomerId, string? Name) : IRequest<IResult<GetCustomerResponse>>;
public record GetCustomerResponse(string FirstName, string LastName, string Email, string PhoneNumber);


public class GetCustomerHandler : IRequestHandler<GetCustomerRequest, IResult<GetCustomerResponse>>
{
    private readonly IQueryUnitOfWork _query;

    public GetCustomerHandler(IQueryUnitOfWork query)
    {
        _query = query;
    }

    public async Task<IResult<GetCustomerResponse>> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
    {
        var query = await _query.Customer.QueryAsync(true, cancellationToken: cancellationToken);

        if (!string.IsNullOrEmpty(request.CustomerId))
        {
            Customer customer = await query.Where(x => x.Id == Guid.Parse(request.CustomerId)).SingleOrDefaultAsync(cancellationToken);

            if (customer is null)
            {
                return Result<GetCustomerResponse>.Fail("Customer not found!");
            }

            GetCustomerResponse result = query.Adapt<GetCustomerResponse>();
            return Result<GetCustomerResponse>.Success(value: result);
        }

        if (!string.IsNullOrEmpty(request.Name))
        {
            var customer = await query
                .Where(x => x.FirstName.ToLower().Contains(request.Name.ToLower()) || x.LastName.ToLower().Contains(request.Name.ToLower()))
                .ToListAsync(cancellationToken);

            if (customer.Count == 0)
            {
                return Result<GetCustomerResponse>.Fail("Customer not found!");
            }

            IEnumerable<GetCustomerResponse> result = customer.Adapt<IEnumerable<GetCustomerResponse>>();
            return Result<GetCustomerResponse>.Success(values: result.ToList());
        }

        var customers = await query.ToListAsync();
        IEnumerable<GetCustomerResponse> response = customers.Adapt<IEnumerable<GetCustomerResponse>>();
        return Result<GetCustomerResponse>.Success(values: response.ToList());

    }
}
