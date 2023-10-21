using Clean.Domain.Repositories.Commands;
using Clean.Domain.Repositories.Queries;

namespace Clean.Application.UnitOfWork.Commands;

public interface ICommandUnitOfWork
{
    IBasketItemCommand BasketItem { get; }
    IBasketCommand Basket { get; }

}
