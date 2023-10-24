using Clean.Domain.Contracts.Abstracts;

namespace Clean.Domain.Contracts.Specifications;


public class ExpressionSpecification<T> : Specification<T>
{
    Func<T, bool> _expression;
    public ExpressionSpecification(Func<T, bool> expression)
    {
        _expression = expression;
    }

    public override bool IsSatisfiedBy(T o)
    {
        return _expression(o);
    }
}
