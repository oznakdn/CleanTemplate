using Clean.Domain.Contracts.Abstracts;

namespace Clean.Domain.Users;

public class User : MongoUserIdentity
{
    private List<Role> _roles = new();
    public ICollection<Role> Roles { get => _roles; }
    public string? RefreshToken { get; private set; }
    public DateTime? ExpiredDate { get; private set; }

    public User(string firstName, string lastName, string username, string email, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Email = email;
        PasswordHash = password;
    }

    private User() { }

    public void SetRefreshToken(string refreshToken, DateTime expiredDate)
    {
        RefreshToken = refreshToken;
        ExpiredDate = expiredDate;
    }

    public void AddRole(string roleTitle, string description) => _roles.Add(new Role(roleTitle, description));

    public void AddRoles(List<Role> roles) => _roles.AddRange(roles);

    public void ClearRoles() => _roles.Clear();

    public void RemoveRole(string roleTitle)
    {
        var role = this._roles.SingleOrDefault(x => x.RoleTitle.Equals(roleTitle));
        if (role != null)
            _roles.Remove(role);
    }


}
