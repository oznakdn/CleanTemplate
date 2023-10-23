using Clean.Domain.Customers;
using Clean.Domain.Repositories.Queries;
using Gleeman.Repository.EFCore.Abstracts.Query;

namespace Clean.Persistence.Repositories.EntityFramework.Queries;

public class CustomerQuery : EFQueryRepository<Customer, ApplicationDbContext>, ICustomerQuery
{
    public CustomerQuery(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
