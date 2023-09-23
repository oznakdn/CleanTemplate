using Clean.Persistence.Repositories.EntityFramework.Interfaces;

namespace Clean.Application.UnitOfWork.Interfaces;

public interface IEfUnitOfWork: IAsyncDisposable
{
    IMapper Mapper { get; }
    IEFProductRepository Product { get; }
    IEFUserRepository User { get; }
    IEFRoleRepository Role { get; }
    void Save();
    Task SaveAsync();
}
