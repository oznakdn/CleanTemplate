using Clean.Application.Results;
using Clean.Domain.Customers;
using Clean.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Clean.Application.Features.Customers.Queries.GetCustomer;

public record GetCustomerRequest(string? CustomerId, string? Name) : IRequest<IDataResult<GetCustomerResponse>>;
public record GetCustomerResponse(string FirstName, string LastName, string Email, string PhoneNumber);


public class GetCustomerHandler : IRequestHandler<GetCustomerRequest, IDataResult<GetCustomerResponse>>
{
    private readonly ICustomerRepository _customer;

    public GetCustomerHandler(ICustomerRepository customer)
    {
        _customer = customer;
    }

    public async Task<IDataResult<GetCustomerResponse>> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
    {
        var query = _customer.GetQueryable();
     
        if (!string.IsNullOrEmpty(request.CustomerId))
        {
            Customer customer =  await query.Where(x => x.Id == Guid.Parse(request.CustomerId)).SingleOrDefaultAsync(cancellationToken);
            var result = new GetCustomerResponse(customer.FirstName, customer.LastName,customer.Email,customer.PhoneNumber);
            return new DataResult<GetCustomerResponse>(result);
        }

        if (!string.IsNullOrEmpty(request.Name))
        {
            var customer = await query
                .Where(x=> x.FirstName.ToLower().Contains(request.Name.ToLower()) || x.LastName.ToLower().Contains(request.Name.ToLower()))
                .ToListAsync(cancellationToken);

            var result = customer.Select(x => new GetCustomerResponse(
                x.FirstName,
                x.LastName,
                x.Email,
                x.PhoneNumber
                )).ToList();
            
            return new DataResult<GetCustomerResponse>(result);
        }

        var customers = await query.ToListAsync();
        var response = customers.Select(x => new GetCustomerResponse(
            x.FirstName,
            x.LastName,
            x.Email,
            x.PhoneNumber)).ToList();

        return new DataResult<GetCustomerResponse>(response);


    }
}
