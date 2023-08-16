namespace Clean.Domain.Entities.NoSQL;

public class Customer : MongoEntity
{

    [BsonElement("fullName")]
    public string FullName { get; set; }

    [BsonElement("email")]
    public string Email { get; set; }
}