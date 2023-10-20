using Clean.Domain.Contracts.Abstracts;

namespace Clean.Domain.Account;

public class Role : MongoRoleIdentity
{
    public Role(string roleTitle, string description)
    {
        RoleTitle = roleTitle;
        Description = description;
        Users = new HashSet<User>();
    }
    private Role() { }

    public ICollection<User> Users { get; set; }

}
