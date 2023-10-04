using Clean.Domain.Contracts.Entities;

namespace Clean.Domain.Contracts.Identites;

public abstract class UserIdentity<TId> : IEntity<TId>
{
   
    public TId Id { get; set; }
    public  string? FirstName { get; set; }
    public  string? LastName { get; set; }
    public  string? Username { get; set; }
    public  string Email { get; set; }
    public  string PasswordHash { get; set; }

    public bool Equals(IEntity<TId>? other)
    {
        return Id.GetHashCode() == other.GetHashCode();
    }
}
