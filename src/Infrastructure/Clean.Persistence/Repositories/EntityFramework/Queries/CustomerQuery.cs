using Clean.Domain.Customers;
using Clean.Domain.Customers.Repositories;
using Clean.Persistence.Repositories.EntityFramework.Common;

namespace Clean.Persistence.Repositories.EntityFramework.Queries;

public class CustomerQuery : EFQueryRepository<Customer, EFContext, Guid>, ICustomerQuery
{
    public CustomerQuery(EFContext context) : base(context)
    {
    }

    public async Task<List<Customer>> GetCustomersAsync(CancellationToken cancellationToken = default)
    => await _context.Customers.AsNoTracking().ToListAsync(cancellationToken);
}
