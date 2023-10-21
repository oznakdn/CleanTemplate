using Clean.Domain.Customers;
using Clean.Domain.Repositories.Commands;
using Gleeman.Repository.EFCore.Abstracts.Command;

namespace Clean.Persistence.Repositories.Commands;

public class CustomerCommand : EFCommandRepository<Customer, ApplicationDbContext>,ICustomerCommand
{
    public CustomerCommand(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
