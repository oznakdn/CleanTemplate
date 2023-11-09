using Clean.Domain.Customers;
using Clean.Domain.Customers.Repositories;
using Gleeman.Repository.EFCore.Abstracts.Command;

namespace Clean.Persistence.Repositories.EntityFramework.Commands;

public class CustomerCommand : EFCommandRepository<Customer, ApplicationDbContext>, ICustomerCommand
{
    public CustomerCommand(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
