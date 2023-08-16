namespace Clean.Domain.Entities.SQL.Abstracts;

public interface IEntity<TKey>
{
    TKey Id { get; set; }
}
