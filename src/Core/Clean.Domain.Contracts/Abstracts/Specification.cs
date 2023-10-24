using Clean.Domain.Contracts.Interfaces;
using Clean.Domain.Contracts.Specifications;

namespace Clean.Domain.Contracts.Abstracts;

public abstract class Specification<T> : ISpecification<T>
{
    public ISpecification<T> And(ISpecification<T> specification)
    {
        return new AndSpecificationz<T>(this, specification);
    }

    public ISpecification<T> Or(ISpecification<T> specification)
    {
        return new OrSpecification<T>(this, specification);
    }

    public ISpecification<T> Not(ISpecification<T> specification)
    {
        return new NotSpecification<T>(specification);
    }

    public abstract bool IsSatisfiedBy(T o);

}
