using Abp.MultiTenancy;
using Insurance.Users;

namespace Insurance.MultiTenancy
{
    public class Tenant : AbpTenant<Tenant, User>
    {

    }
}
