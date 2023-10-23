using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.Account;

public class User : IEntity<string>
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement]
    public string Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public string? RefreshToken { get; private set; }
    public DateTime? ExpiredDate { get; private set; }
    public string? RoleId { get; private set; }
    public bool IsDeleted { get; private set; }

    public User(string firstName, string lastName, string username, string email, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Email = email;
        PasswordHash = password;
    }

    public User(string firstName, string lastName, string username, string email, string password, string? roleId)
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

    public bool Equals(IEntity<string>? other)
    {
        return Id.GetHashCode() == other.GetHashCode();
    }
}
