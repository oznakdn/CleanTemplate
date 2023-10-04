using Clean.Domain.Contracts.Repositories;

namespace Clean.Domain.Identities.User;

public interface IEFUserRepository : IEFRepository<AppUser, Guid>
{
}
