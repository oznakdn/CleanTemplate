using MongoDB.Bson.Serialization.Attributes;

namespace Clean.Domain.Contracts.Abstracts;

public abstract class MongoUserIdentity : MongoEntity
{
    [BsonElement]
    public string? FirstName { get; set; }

    [BsonElement]
    public string? LastName { get; set; }

    [BsonElement]
    public string? Username { get; set; }

    [BsonElement]
    public string Email { get; set; }

    [BsonElement]
    public string PasswordHash { get; set; }

}
