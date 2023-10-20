using Clean.Domain.Repositories.Queries;

namespace Clean.Application.UnitOfWork.Queries;

public interface IQueryUnitOfWork
{
    IBasketItemQuery basketItemQuery { get; }
}
