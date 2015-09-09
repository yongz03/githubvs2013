using EntityFramework.DynamicFilters;
using Insurance.EntityFramework;
using Insurance.Migrations.SeedData;

namespace Insurance.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<InsuranceDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(InsuranceDbContext context)
        {
            context.DisableAllFilters();
            //  This method will be called after migrating to the latest version.
            new DefaultInsuranceRateBuilder(context).Build();
            new DefaultTenantRoleAndUserBuilder(context).Build();

        }
    }
}
