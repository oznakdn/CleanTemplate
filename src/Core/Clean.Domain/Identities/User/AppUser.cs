using Clean.Domain.Contracts.Identites;
using Clean.Domain.Identities.Role;

namespace Clean.Domain.Identities.User;

public class AppUser : UserIdentity<Guid>
{
    public string? RefreshToken { get; set; }
    public DateTime? ExpiredDate { get; set; }
    public Guid? RoleId { get; set; }
    public AppRole Role { get; set; }
}
