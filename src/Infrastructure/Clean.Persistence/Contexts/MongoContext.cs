using Clean.Domain.Contracts.Interfaces;
using Clean.Persistence.Options;
using Clean.Persistence.Options.Interfaces;

namespace Clean.Persistence.Contexts;

public abstract class MongoContext<TCollection>
where TCollection : IDocument
{
    protected readonly IMongoCollection<TCollection> _collection;
    private readonly IMongoClient _client;
 
    public MongoContext(IMongoOption option, string collection)
    {
        IMongoDatabase database;
        if (!string.IsNullOrEmpty(option.ConnectionString) &&
            !string.IsNullOrEmpty(option.DatabaseName) &&
            !string.IsNullOrEmpty(collection))
        {
            _client = new MongoClient(option.ConnectionString);
            database = _client.GetDatabase(option.DatabaseName);
            _collection = database.GetCollection<TCollection>(collection);
        }
        else
        {
            throw new ArgumentNullException(nameof(MongoOption));

        }
    }
}
