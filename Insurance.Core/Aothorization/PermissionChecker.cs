using Abp.Authorization;
using Insurance.Authorization.Roles;
using Insurance.MultiTenancy;
using Insurance.Users;

namespace Insurance.Aothorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
