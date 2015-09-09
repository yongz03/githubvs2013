using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace Insurance.Application
{
    [DependsOn(typeof(InsuranceCoreModule), typeof(AbpAutoMapperModule))]
    public class InsuranceApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            
            //We must declare mappings to be able to use AutoMapper
            DtoMappings.Map();
        }
    }
}
