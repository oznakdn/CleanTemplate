using Clean.Domain.Customers;
using Clean.Domain.Customers.Repositories;
using Gleeman.Repository.EFCore.Abstracts.Query;

namespace Clean.Persistence.Repositories.EntityFramework.Queries;

public class CustomerQuery : EFQueryRepository<Customer, ApplicationDbContext>, ICustomerQuery
{
    public CustomerQuery(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Customer>> GetCustomersAsync(CancellationToken cancellationToken = default)
    => await _dbContext.Customers.AsNoTracking().ToListAsync(cancellationToken);
}
