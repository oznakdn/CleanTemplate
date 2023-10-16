using Clean.Domain.Contracts.Abstracts;

namespace Clean.Domain.Users;

public class Role : ValueObject
{
    public Role(string roleTitle, string description)
    {
        RoleTitle = roleTitle;
        Description = description;
    }
    private Role() { }

    public string RoleTitle { get; private set; }
    public string Description { get; private set; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return RoleTitle;
        yield return Description;
    }
}
