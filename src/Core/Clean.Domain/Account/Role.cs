using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.Account;

public class Role : IEntity<string>
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement]
    public string Id { get; private set; }
    public string RoleTitle { get; private set; }
    public string Description { get; private set; }
    public bool IsDeleted { get; private set; }

    public Role(string roleTitle, string description)
    {
        RoleTitle = roleTitle;
        Description = description;
    }
    private Role() { }

    

    public bool Equals(IEntity<string>? other)
    {
        return Id.GetHashCode() == other.GetHashCode();
    }
}
