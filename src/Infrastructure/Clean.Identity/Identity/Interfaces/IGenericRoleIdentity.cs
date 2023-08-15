using Clean.Domain.Identities.Abstracts;

namespace Clean.Identity.Identity.Interfaces;

public interface IGenericRoleIdentity<TRole,TKey>
where TRole : RoleIdentity<TKey>
{
}
