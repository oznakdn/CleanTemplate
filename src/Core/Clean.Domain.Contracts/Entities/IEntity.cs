namespace Clean.Domain.Contracts.Entities;


public interface IEntity<TId> : IEquatable<IEntity<TId>>
{
    TId Id { get; set; }
}
