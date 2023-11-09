using Clean.Domain.Orders;
using Gleeman.Repository.EFCore.Interfaces.Query;

namespace Clean.Domain.Orders.Repositories;

public interface IOrderQuery : IEFQueryAsyncRepository<Order>
{
}
