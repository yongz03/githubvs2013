using System;
using System.Data.Common;
using Abp.Collections;
using Abp.Modules;
using Abp.TestBase;
using Castle.MicroKernel.Registration;
using EntityFramework.DynamicFilters;
using Insurance.Application;
using Insurance.EntityFramework;

namespace Insurance.Test
{
    public abstract class InsuranceTestBase : AbpIntegratedTestBase
    {
        protected InsuranceTestBase()
        {
            //Fake DbConnection using Effort!
            LocalIocManager.IocContainer.Register(
                Component.For<DbConnection>()
                    .UsingFactoryMethod(Effort.DbConnectionFactory.CreateTransient)
                    .LifestyleSingleton()
                );

            //Seed initial data
            UsingDbContext(context => new InsuranceInitialDataBuilder().Build(context));
        }

        protected override void AddModules(ITypeList<AbpModule> modules)
        {
            base.AddModules(modules);

            //Adding testing modules. Depended modules of these modules are automatically added.
            modules.Add<InsuranceApplicationModule>();
            modules.Add<InsuranceDataModule>();
        }

        public void UsingDbContext(Action<InsuranceDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<InsuranceDbContext>())
            {
                context.DisableAllFilters();
                action(context);
                context.SaveChanges();
            }
        }

        public T UsingDbContext<T>(Func<InsuranceDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<InsuranceDbContext>())
            {
                context.DisableAllFilters();
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
