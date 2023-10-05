namespace Clean.Domain.Contracts.Entities;

public abstract class AgreegateRoot<T,TId> : IEntity<TId>
where T : IEntity<TId>
{
    public virtual TId Id { get; set; }
    public bool IsDeleted { get; set; } = false;

    public AgreegateRoot(TId id)
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

    public static bool operator ==(AgreegateRoot<T,TId> lhs, AgreegateRoot<T,TId> rhs)
    {
        return lhs.Equals(rhs);
    }

    public static bool operator !=(AgreegateRoot<T,TId> lhs, AgreegateRoot<T,TId> rhs)
    {
        return !(lhs == rhs);
    }

    private bool IsValid(TId id)
    {
        return id is int || id is long || id is Guid;
    }
}
