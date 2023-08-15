using Clean.Domain.Identities.Abstracts;

namespace Clean.Identity.Identity.Interfaces;

public interface IGenericUserIdentity<TUser, TKey>
where TUser : UserIdentity<TKey>, new()
{
    Task<TUser> CreateUserAsync(TUser user);
    Task UpdateUserAsync(TUser user);
    Task<TUser> SigningUserAsync(string email, string password);
}
