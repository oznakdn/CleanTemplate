using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Clean.Domain.Entities.Abstracts;

public abstract class MongoEntity : IMongoEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement]
    public string Id { get; set; }
}
