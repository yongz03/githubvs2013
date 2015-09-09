using System.Reflection;
using Abp.Application.Services;
using Abp.Modules;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;
using Insurance.Application;

namespace Insurance
{
    [DependsOn(typeof(AbpWebApiModule), typeof(InsuranceApplicationModule))]
    public class InsuranceWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(InsuranceApplicationModule).Assembly, "app")
                .Build();
        }
    }
}
