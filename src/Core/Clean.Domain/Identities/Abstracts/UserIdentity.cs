﻿using Clean.Domain.Entities.Abstracts;

namespace Clean.Domain.Identities.Abstracts;

public abstract class UserIdentity<TKey> : Entity<TKey>
{
    public UserIdentity()
    {
        
    }
    public virtual string? FirstName { get; set; }
    public virtual string? LastName { get; set;}
    public virtual string? Username { get; set; }
    public virtual string Email { get; set; }
    public virtual string PasswordHash { get; set; }

    public virtual TKey? RoleId { get; set; }
    public virtual RoleIdentity<TKey> Role { get; set; }
}
