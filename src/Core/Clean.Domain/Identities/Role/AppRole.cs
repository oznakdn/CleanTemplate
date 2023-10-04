using Clean.Domain.Contracts.Identites;
using Clean.Domain.Identities.User;

namespace Clean.Domain.Identities.Role;

public class AppRole : RoleIdentity<Guid>
{
    public ICollection<AppUser> Users { get; set; }
}
