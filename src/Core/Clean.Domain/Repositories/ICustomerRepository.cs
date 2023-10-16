using Clean.Domain.Contracts.Interfaces;
using Clean.Domain.Customers;

namespace Clean.Domain.Repositories;

public interface ICustomerRepository : IEFRepository<Customer,Guid>
{
}
