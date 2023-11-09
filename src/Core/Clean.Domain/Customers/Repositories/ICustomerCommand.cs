using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.Customers.Repositories;

public interface ICustomerCommand :IEFCommandRepository<Customer,Guid>
{
}
