using MongoDB.Driver;

namespace Clean.Domain.Contracts.Interfaces;

public interface IMongoCommandRepository<TCollection>
    where TCollection : IDocument
{

    // Create

    Task<TCollection> CreateAsync(TCollection document, CancellationToken cancellationToken = default(CancellationToken));
    Task InsertAsync(TCollection document, CancellationToken cancellationToken = default(CancellationToken));
    Task<IEnumerable<TCollection>> CreateRangeAsync(IEnumerable<TCollection> documents, CancellationToken cancellationToken = default(CancellationToken));
    Task InsertRangeAsync(IEnumerable<TCollection> documents, CancellationToken cancellationToken = default(CancellationToken));
    TCollection Create(TCollection document);
    void Insert(TCollection document);
    IEnumerable<TCollection> CreateRange(IEnumerable<TCollection> documents);
    void InsertRange(IEnumerable<TCollection> documents);

    // Update

    Task<TCollection> UpdateAsync(FilterDefinition<TCollection> filter, TCollection collection, CancellationToken cancellationToken = default);
    Task EditAsync(FilterDefinition<TCollection> filter, TCollection collection, CancellationToken cancellationToken = default);
    Task EditRangeAsync(FilterDefinition<TCollection> filter, UpdateDefinition<TCollection> update, CancellationToken cancellationToken = default);
    TCollection Update(FilterDefinition<TCollection> filter, TCollection collection);
    void Edit(FilterDefinition<TCollection> filter, TCollection collection);
    void EditRange(FilterDefinition<TCollection> filter, UpdateDefinition<TCollection> update);


    // Delete

    Task DeleteAsync(FilterDefinition<TCollection> filter, CancellationToken cancellationToken = default(CancellationToken));
    Task DeleteRangeAsync(FilterDefinition<TCollection> filter, CancellationToken cancellationToken = default(CancellationToken));
    void Delete(FilterDefinition<TCollection> filter);
    void DeleteRange(FilterDefinition<TCollection> filter);


}
