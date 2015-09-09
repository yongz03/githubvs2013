using Abp.Authorization.Users;
using Insurance.MultiTenancy;

namespace Insurance.Users
{
    public class User : AbpUser<Tenant, User>
    {

    }
}
