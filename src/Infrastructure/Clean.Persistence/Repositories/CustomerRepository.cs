using Clean.Domain.Customers;
using Clean.Domain.Repositories;
using Clean.Persistence.Repositories.Common;

namespace Clean.Persistence.Repositories;

public class CustomerRepository : EFRepository<Customer, ApplicationDbContext, Guid>, ICustomerRepository
{
    public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
