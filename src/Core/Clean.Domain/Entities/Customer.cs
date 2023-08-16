using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Clean.Domain.Entities;

public class Customer: MongoEntity
{
    
    [BsonElement("fullName")]
    public string FullName { get; set; }

    [BsonElement("email")]
    public string Email { get; set; }
}