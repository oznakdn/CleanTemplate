namespace Clean.Application.UnitOfWork.Interfaces;

public interface IEfUnitOfWork: IAsyncDisposable
{
    IMapper Mapper { get; }
    IEFProductRepository Product { get; }
    IEFUserRepository User { get; }
    void Save();
    Task SaveAsync();
}
