using Clean.Domain.Contracts.Interfaces;
using System.Linq.Expressions;

namespace Clean.Domain.Contracts.Abstracts;

public abstract class Specification<TEntity> : ISpecification<TEntity>
{
    public abstract Expression<Func<TEntity, bool>> ToExpression();

    public bool IsSatisfiedBy(TEntity entity)
    {
        Func<TEntity, bool> predicate = ToExpression().Compile();
        return predicate(entity);
    }
}
