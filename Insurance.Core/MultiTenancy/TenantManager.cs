using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using Insurance.Authorization.Roles;
using Insurance.Users;

namespace Insurance.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, Role, User>
    {
        public TenantManager(IRepository<Tenant> tenantRepository)
            : base(tenantRepository)
        {

        }
    }
}
