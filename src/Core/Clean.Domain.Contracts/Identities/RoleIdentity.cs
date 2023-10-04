using Clean.Domain.Contracts.Entities;

namespace Clean.Domain.Contracts.Identites;

public abstract class RoleIdentity<TId> : IEntity<TId>
{
    public TId Id { get; set; }
    public string RoleTitle { get; set; }
    public string Description { get; set; }

    public bool Equals(IEntity<TId>? other)
    {
        return Id.GetHashCode() == other.GetHashCode();
    }
}
