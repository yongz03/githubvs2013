using System.Reflection;
using Abp.Modules;

namespace Insurance
{
    public class InsuranceCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
