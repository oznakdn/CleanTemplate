namespace Clean.Domain.Identities.NoSQL.Abstracts;

public abstract class MongoRoleIdentity:MongoEntity
{

    [BsonElement]
    public string RoleTitle { get; set; }

    [BsonElement]
    public string Description { get; set; }

    public ICollection<MongoUserIdentity> Users { get; set; }
}
