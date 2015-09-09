using Abp.Authorization.Roles;
using Insurance.MultiTenancy;
using Insurance.Users;

namespace Insurance.Authorization.Roles
{
    public class Role : AbpRole<Tenant, User>
    {

    }
}
