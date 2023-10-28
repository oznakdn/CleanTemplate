using Clean.Domain.Orders;
using Gleeman.Repository.EFCore.Interfaces.Query;

namespace Clean.Domain.Repositories.Queries;

public interface IOrderQuery:IEFQueryAsyncRepository<Order>
{
}
