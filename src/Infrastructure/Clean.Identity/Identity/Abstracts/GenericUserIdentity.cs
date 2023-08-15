using Clean.Domain.Identities.Abstracts;
using Clean.Identity.Helpers;
using Clean.Identity.Identity.Interfaces;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Clean.Identity.Identity.Abstracts;

public class GenericUserIdentity<TUser, TContext, TKey> : IGenericUserIdentity<TUser, TKey>
where TUser : UserIdentity<TKey>, new()
where TContext : DbContext
{
    private readonly TContext _context;
    protected GenericUserIdentity(TContext context)
    {
        _context = context;
    }

    public async Task<TUser> CreateUserAsync(TUser user)
    {
        user.PasswordHash = user.PasswordHash.HashPassword();
        user.Username = user.Username ?? user.Email;
        _context.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<TUser> SigningUserAsync(string email, string password)
    {
        var userExist =await _context.Set<TUser>().SingleOrDefaultAsync(x => x.Email == email && x.PasswordHash == password);
        if(userExist != null)
        {
            return userExist;
        }
        return null;
    }

    public async Task UpdateUserAsync(TUser user)
    {
        _context.Set<TUser>().Update(user);
        await _context.SaveChangesAsync();
    }
}
