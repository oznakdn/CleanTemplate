using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.Orders.Repositories;

public interface IOrderQuery : IEFQueryRepository<Order,Guid>
{
}
