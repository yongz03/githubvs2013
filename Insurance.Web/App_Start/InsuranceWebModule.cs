using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Localization;
using Abp.Localization.Sources.Xml;
using Abp.Modules;
using Insurance.Application;

namespace Insurance.Web
{
    [DependsOn(typeof(InsuranceDataModule), typeof(InsuranceApplicationModule), typeof(InsuranceWebApiModule))]
    public class InsuranceWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Add/remove languages for your application
            Configuration.Localization.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flag-england", true));
            Configuration.Localization.Languages.Add(new LanguageInfo("zh-CN", "简体中文", "famfamfam-flag-cn"));

            //Add/remove localization sources here
#pragma warning disable 618
            Configuration.Localization.Sources.Add(new XmlLocalizationSource(
#pragma warning restore 618
                    InsuranceConsts.LocalizationSourceName,
                    HttpContext.Current.Server.MapPath("~/Localization/Insurance")
                    )
                );

            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<InsuranceNavigationProvider>();

            //configure insurance rates
            Configuration.Settings.Providers.Add<InsuranceRatesProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
