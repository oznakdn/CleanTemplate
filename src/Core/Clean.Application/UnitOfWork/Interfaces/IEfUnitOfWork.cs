using Clean.Domain.Entities.Product;
using Clean.Domain.Identities.Role;
using Clean.Domain.Identities.User;

namespace Clean.Application.UnitOfWork.Interfaces;

public interface IEfUnitOfWork: IAsyncDisposable
{
    IMapper Mapper { get; }
    IEFProductRepository Product { get; }
    IEFUserRepository User { get; }
    IEFRoleRepository Role { get; }
    void Save();
    Task SaveAsync(CancellationToken cancellationToken = default);
}
