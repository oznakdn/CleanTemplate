using Clean.Domain.Customers;
using Gleeman.Repository.EFCore.Interfaces.Query;

namespace Clean.Domain.Repositories.Queries;

public interface ICustomerQuery :
    IEFQueryAsyncRepository<Customer>,
    IEFQuerySyncRepository<Customer>
{
}
