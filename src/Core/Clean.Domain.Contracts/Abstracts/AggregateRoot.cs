using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.Contracts.Abstracts;

public abstract class AggregateRoot<T, TId> : Entity<TId>
where T : IEntity<TId>
{
    protected AggregateRoot(TId id) : base(id)
    {
        if (!IsValid(id))
            throw new ArgumentException("Identifier format is wrong!");
         Id = id;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Entity<TId>);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public bool Equals(IEntity<TId>? other)
    {
        return Id.GetHashCode() == other.GetHashCode();
    }

    public static bool operator ==(AggregateRoot<T, TId> lhs, AggregateRoot<T, TId> rhs)
    {
        return lhs.Equals(rhs);
    }

    public static bool operator !=(AggregateRoot<T, TId> lhs, AggregateRoot<T, TId> rhs)
    {
        return !(lhs == rhs);
    }

    private bool IsValid(TId id)
    {
        return id is int || id is long || id is Guid;
    }
}
