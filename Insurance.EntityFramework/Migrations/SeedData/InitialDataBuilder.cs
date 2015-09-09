using Insurance.EntityFramework;
using Insurance.Migrations.SeedData;

namespace ModuleZero.Migrations.SeedData
{
    public class InitialDataBuilder
    {
        private readonly InsuranceDbContext _context;

        public InitialDataBuilder(InsuranceDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            new DefaultTenantRoleAndUserBuilder(_context).Build();
        }
    }
}
