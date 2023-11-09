using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.Contracts.Abstracts;

public abstract class Entity<TId> : IEntity<TId>
{
    public virtual TId Id { get; protected set; }

    public bool IsDeleted { get; protected set; }

    public Entity(TId id)
    {
        if (!IsValid(id))
            throw new ArgumentException("Identifier format is wrong!");
        Id = id;
        IsDeleted = false;
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

    public static bool operator ==(Entity<TId> lhs, Entity<TId> rhs)
    {
        return lhs.Equals(rhs);
    }

    public static bool operator !=(Entity<TId> lhs, Entity<TId> rhs)
    {
        return !(lhs == rhs);
    }

    private bool IsValid(TId id)
    {
        return id is int || id is long || id is Guid;
    }
}
