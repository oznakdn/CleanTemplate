namespace Clean.Domain.Contracts.Interfaces;

public interface ISpecification<T>
{
    ISpecification<T> And (ISpecification<T> specification);
    ISpecification<T> Or(ISpecification<T> specification);
    ISpecification<T> Not(ISpecification<T> specification);
    bool IsSatisfiedBy(T o);
}
