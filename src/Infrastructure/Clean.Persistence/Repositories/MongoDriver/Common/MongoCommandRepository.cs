using Clean.Domain.Contracts.Interfaces;
using Clean.Persistence.Options.Interfaces;

namespace Clean.Persistence.Repositories.MongoDriver.Common;

public abstract class MongoCommandRepository<TCollection> : MongoContext<TCollection>, IMongoCommandRepository<TCollection>
    where TCollection : IDocument
{
    protected MongoCommandRepository(IMongoOption option, string CollectionName) : base(option, $"{CollectionName}s")
    {
    }


    // Create

    public virtual async Task<TCollection> CreateAsync(TCollection document, CancellationToken cancellationToken = default)
    {
        await _collection.InsertOneAsync(document);
        return document;
    }

    public virtual async Task<IEnumerable<TCollection>> CreateRangeAsync(IEnumerable<TCollection> documents, CancellationToken cancellationToken = default)
    {
        await _collection.InsertManyAsync(documents);
        return documents;
    }

    public virtual async Task InsertAsync(TCollection document, CancellationToken cancellationToken = default)
    {
        await _collection.InsertOneAsync(document);
    }

    public virtual async Task InsertRangeAsync(IEnumerable<TCollection> documents, CancellationToken cancellationToken = default)
    {
        await _collection.InsertManyAsync(documents);
    }

    public virtual void Insert(TCollection document)
    {
        _collection.InsertOne(document);
    }

    public virtual TCollection Create(TCollection document)
    {
        _collection.InsertOne(document);
        return document;
    }

    public virtual void InsertRange(IEnumerable<TCollection> documents)
    {
        _collection.InsertMany(documents);
    }

    public virtual IEnumerable<TCollection> CreateRange(IEnumerable<TCollection> documents)
    {
        _collection.InsertMany(documents);
        return documents;
    }


    // Update

    public virtual async Task<TCollection> UpdateAsync(FilterDefinition<TCollection> filter, TCollection collection, CancellationToken cancellationToken = default)
    {
        await _collection.ReplaceOneAsync(filter, collection);
        return collection;
    }

    public virtual async Task EditAsync(FilterDefinition<TCollection> filter, TCollection collection, CancellationToken cancellationToken = default)
    {
        await _collection.ReplaceOneAsync(filter, collection);
    }

    public virtual async Task EditRangeAsync(FilterDefinition<TCollection> filter, UpdateDefinition<TCollection> update, CancellationToken cancellationToken = default)
    {
        await _collection.UpdateManyAsync(filter, update);

    }

    public virtual TCollection Update(FilterDefinition<TCollection> filter, TCollection collection)
    {
        _collection.ReplaceOne(filter, collection);
        return collection;
    }

    public virtual void Edit(FilterDefinition<TCollection> filter, TCollection collection)
    {
        _collection.ReplaceOne(filter, collection);
    }

    public virtual void EditRange(FilterDefinition<TCollection> filter, UpdateDefinition<TCollection> update)
    {
        _collection.UpdateMany(filter, update);
    }


    // Delete

    public virtual async Task DeleteAsync(FilterDefinition<TCollection> filter, CancellationToken cancellationToken = default)
    {
        await _collection.DeleteOneAsync(filter);
    }

    public virtual async Task DeleteRangeAsync(FilterDefinition<TCollection> filter, CancellationToken cancellationToken = default)
    {
        await _collection.DeleteManyAsync(filter);
    }

    public virtual void Delete(FilterDefinition<TCollection> filter)
    {
        _collection.DeleteOne(filter);
    }

    public virtual void DeleteRange(FilterDefinition<TCollection> filter)
    {
        _collection.DeleteMany(filter);
    }

}
