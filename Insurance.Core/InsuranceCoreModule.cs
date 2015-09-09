using System.Reflection;
using Abp.Modules;
using Abp.Zero;

namespace Insurance
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class InsuranceCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
