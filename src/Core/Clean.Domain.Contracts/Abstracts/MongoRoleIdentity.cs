using MongoDB.Bson.Serialization.Attributes;

namespace Clean.Domain.Contracts.Abstracts;

public abstract class MongoRoleIdentity : MongoEntity
{
    [BsonElement]
    public string RoleTitle { get; set; }

    [BsonElement]
    public string Description { get; set; }
}
