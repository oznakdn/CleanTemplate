using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Clean.Domain.Contracts.Entities;


public abstract class MongoEntity : IMongoEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement]
    public string Id { get; set; }
}
