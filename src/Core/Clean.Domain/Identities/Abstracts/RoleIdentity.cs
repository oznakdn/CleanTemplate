using Clean.Domain.Entities.Abstracts;

namespace Clean.Domain.Identities.Abstracts;

public abstract class RoleIdentity<TKey> : Entity<TKey>
{
    public RoleIdentity()
    {
        
    }
    public string RoleTitle { get; set; }
    public string Description { get; set; }
    public ICollection<UserIdentity<TKey>> Users { get; set; }
}
