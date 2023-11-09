using Clean.Persistence.Options.Interfaces;

namespace Clean.Persistence.Options;

public class MongoOption : IMongoOption
{
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
}
