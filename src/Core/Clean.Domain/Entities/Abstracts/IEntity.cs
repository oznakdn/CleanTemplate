namespace Clean.Domain.Entities.Abstracts;

public interface IEntity<TKey>
{
    TKey Id { get; set; }
}
