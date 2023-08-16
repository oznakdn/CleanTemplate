using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Clean.Domain.Entities;

public class Customer:Entity<ObjectId>
{
    [IgnoreDataMember]
    public override ObjectId Id { get;set; }

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("_id")]
    public string ID { get; set; }
    [BsonElement("fullName")]
    public string FullName { get; set; }

    [BsonElement("email")]
    public string Email { get; set; }
}