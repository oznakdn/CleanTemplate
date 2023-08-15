using AutoMapper;
using Clean.Domain.Identities;
using Clean.Persistence.Contexts;
using Clean.Persistence.Repositories.Abstracts;
using Clean.Persistence.Repositories.Interfaces;

namespace Clean.Persistence.Repositories;

public class UserRepository : GenericRepository<AppUser, ApplicationDbContext, Guid>,IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }
}
