using Clean.Domain.Contracts.Entities;

namespace Clean.Domain.Entities.Customer;

public class Customer : MongoEntity
{

    [BsonElement("fullName")]
    public string FullName { get; set; }

    [BsonElement("email")]
    public string Email { get; set; }
}