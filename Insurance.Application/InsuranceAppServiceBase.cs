using Abp.Application.Services;

namespace Insurance.Application
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class InsuranceAppServiceBase : ApplicationService
    {
        protected InsuranceAppServiceBase()
        {
            LocalizationSourceName = InsuranceConsts.LocalizationSourceName;
        }
    }
}