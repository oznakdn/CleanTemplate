using Clean.Domain.Contracts.Abstracts;
using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.Contracts.Specifications;


public class NotSpecification<T> : Specification<T>
{

    ISpecification<T> _otherSpecification;

    public NotSpecification(ISpecification<T> otherSpecification)
    {
        _otherSpecification = otherSpecification;
    }

    public override bool IsSatisfiedBy(T o)
    {
        return !_otherSpecification.IsSatisfiedBy(o);
    }
}
