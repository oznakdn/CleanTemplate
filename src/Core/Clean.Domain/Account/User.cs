using Clean.Domain.Contracts.Abstracts;

namespace Clean.Domain.Account;

public class User : MongoUserIdentity
{
  
    public string? RefreshToken { get; private set; }
    public DateTime? ExpiredDate { get; private set; }
    public string? RoleId { get; private set; }
    public Role? Role { get; private set; }

    public User(string firstName, string lastName, string username, string email, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Email = email;
        PasswordHash = password;
    }

    public User(string firstName, string lastName, string username, string email, string password,string? roleId)
    {
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Email = email;
        PasswordHash = password;
        RoleId = roleId;
    }

    private User() { }

    public void SetRefreshToken(string refreshToken, DateTime expiredDate)
    {
        RefreshToken = refreshToken;
        ExpiredDate = expiredDate;
    }
}
