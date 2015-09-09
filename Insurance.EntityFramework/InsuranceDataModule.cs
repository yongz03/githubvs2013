using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using Insurance.EntityFramework;

namespace Insurance
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(InsuranceCoreModule))]
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
