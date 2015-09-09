using Abp.Web.Mvc.Controllers;

namespace Insurance.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class InsuranceControllerBase : AbpController
    {
        protected InsuranceControllerBase()
        {
            LocalizationSourceName = InsuranceConsts.LocalizationSourceName;
        }
    }
}