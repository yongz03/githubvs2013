using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using Insurance.EntityFramework;

namespace Insurance
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(InsuranceCoreModule))]
    public class InsuranceDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<InsuranceDbContext>(null); //must comment out it for testing
        }

    }
}
