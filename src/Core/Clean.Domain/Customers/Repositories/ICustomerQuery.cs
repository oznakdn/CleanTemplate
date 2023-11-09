using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.Customers.Repositories;

public interface ICustomerQuery : IEFQueryRepository<Customer,Guid>
{
    Task<List<Customer>> GetCustomersAsync(CancellationToken cancellationToken = default);
}
