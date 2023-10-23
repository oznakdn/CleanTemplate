namespace Clean.Domain.Contracts.Interfaces;

public interface ISpecification<TEntity>
{
    bool IsSatisfiedBy(TEntity entity);
}
