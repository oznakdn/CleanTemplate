using Clean.Domain.Contracts.Abstracts;
using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.Contracts.Specifications;

public class AndSpecificationz<T> : Specification<T>
{
    ISpecification<T> _leftSpecification;
    ISpecification<T> _rightSpecification;
    public AndSpecificationz(ISpecification<T> leftSpecification, ISpecification<T> rightSpecification)
    {
        _leftSpecification = leftSpecification;
        _rightSpecification = rightSpecification;
    }
    public override bool IsSatisfiedBy(T o)
    {
        return _leftSpecification.IsSatisfiedBy(o) && _rightSpecification.IsSatisfiedBy(o);
    }
}
