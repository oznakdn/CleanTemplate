namespace Clean.Domain.Contracts.Interfaces;


public interface IEntity<TId> : IEquatable<IEntity<TId>>
{
    TId Id { get; set; }
    bool IsDeleted { get; set; }
}
