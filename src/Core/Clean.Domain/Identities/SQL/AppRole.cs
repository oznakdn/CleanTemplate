namespace Clean.Domain.Identities.SQL;

public class AppRole : RoleIdentity<Guid>
{
    public ICollection<AppUser>Users { get; set; }
}
