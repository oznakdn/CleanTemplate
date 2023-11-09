using Clean.Domain.Contracts.Interfaces;
using Clean.Domain.Shared;

namespace Clean.Domain.Users;

public class User : IDocument
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

    public static TResult<User> CreateUser(string firstName, string lastName, string username, string email, string password)
    {
        var errors = new List<string>();
        if (string.IsNullOrEmpty(firstName)) errors.Add("First name cannot be empty!");
        if (string.IsNullOrEmpty(lastName)) errors.Add("Last name cannot be empty!");
        if (string.IsNullOrEmpty(username)) errors.Add("Username cannot be empty!");
        if (string.IsNullOrEmpty(email)) errors.Add("Email cannot be empty!");
        if (string.IsNullOrEmpty(password)) errors.Add("Password cannot be empty!");

        if (errors.Count > 0)
            return TResult<User>.Fail(errors);

        var user = new User(firstName, lastName, username, email, password);
        return TResult<User>.Ok(user);
    }

    public static TResult<User> CreateUser(string firstName, string lastName, string username, string email, string password, string roleId)
    {
        var errors = new List<string>();
        if (string.IsNullOrEmpty(firstName)) errors.Add("First name cannot be empty!");
        if (string.IsNullOrEmpty(lastName)) errors.Add("Last name cannot be empty!");
        if (string.IsNullOrEmpty(username)) errors.Add("Username cannot be empty!");
        if (string.IsNullOrEmpty(email)) errors.Add("Email cannot be empty!");
        if (string.IsNullOrEmpty(password)) errors.Add("Password cannot be empty!");
        if (string.IsNullOrEmpty(roleId)) errors.Add("RoleId cannot be empty!");

        if (errors.Count > 0)
            return TResult<User>.Fail(errors);

        var user = new User(firstName, lastName, username, email, password, roleId);
        return TResult<User>.Ok(user);

    }



    protected User(string firstName, string lastName, string username, string email, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Email = email;
        PasswordHash = password;
    }

    protected User(string firstName, string lastName, string username, string email, string password, string? roleId)
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
