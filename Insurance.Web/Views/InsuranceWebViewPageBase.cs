using Abp.Web.Mvc.Views;

namespace Insurance.Web.Views
{
    public abstract class InsuranceWebViewPageBase : InsuranceWebViewPageBase<dynamic>
    {

    }

    public abstract class InsuranceWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected InsuranceWebViewPageBase()
        {
            LocalizationSourceName = InsuranceConsts.LocalizationSourceName;
        }
    }
}