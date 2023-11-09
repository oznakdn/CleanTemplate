using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.Baskets.Repositories;

public interface IBasketCommand :IEFCommandRepository<Basket,Guid>

{
}
