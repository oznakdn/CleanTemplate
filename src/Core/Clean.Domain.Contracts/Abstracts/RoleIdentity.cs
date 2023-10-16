using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.Contracts.Abstracts;

public abstract class RoleIdentity<TId> : IEntity<TId>
{
    public TId Id { get; set; }
    public string RoleTitle { get; set; }
    public string Description { get; set; }
    public bool IsDeleted { get; set; }

    public bool Equals(IEntity<TId>? other)
    {
        return Id.GetHashCode() == other.GetHashCode();
    }
}
