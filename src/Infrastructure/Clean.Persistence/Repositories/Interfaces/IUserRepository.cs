using Clean.Domain.Identities;

namespace Clean.Persistence.Repositories.Interfaces;

public interface IUserRepository:IGenericRepository<AppUser,Guid>
{
}
