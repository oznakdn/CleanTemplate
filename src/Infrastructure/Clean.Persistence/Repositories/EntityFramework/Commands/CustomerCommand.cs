using Clean.Domain.Customers;
using Clean.Domain.Customers.Repositories;
using Clean.Persistence.Repositories.EntityFramework.Common;

namespace Clean.Persistence.Repositories.EntityFramework.Commands;

public class CustomerCommand : EFCommandRepository<Customer, EFContext, Guid>, ICustomerCommand
{
    public CustomerCommand(EFContext context) : base(context)
    {
    }
}
