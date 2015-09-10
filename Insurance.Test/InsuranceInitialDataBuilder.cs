using System.Data.Entity.Migrations;
using System.Linq;
using Insurance.EntityFramework;
using Insurance.Customers;

namespace Insurance.Test
{

    public class InsuranceInitialDataBuilder
    {
        public void Build(InsuranceDbContext context)
        {
            //Add some insurances
            context.Insurances.AddOrUpdate(
                t => t.CoverAmount,
                new Insurances.LifeInsurance
                {
                    CoverAmount = 1000
                },
                new Insurances.LifeInsurance
                {
                    CoverAmount = 10000
                },
                new Insurances.LifeInsurance
                {
                    CoverAmount = 100000
                },
                new Insurances.ProtectInsurance
                {
                    CoverAmount = 5000
                });

            context.SaveChanges();

            //Add some customers            
            context.Customers.AddOrUpdate(
                p => p.FirstName,
                new Customer { FirstName = "Isaac", LastName = "Asimov", SelectedInsurance = context.Insurances.Single(i => i.CoverAmount == 1000), Gender = "F" },
                new Customer { FirstName = "Thomas", LastName = "More", SelectedInsurance = context.Insurances.Single(i => i.CoverAmount == 10000), Gender = "M", SelectedInsuranceId = 100 },
                new Customer { FirstName = "George", LastName = "Orwell", SelectedInsurance = context.Insurances.Single(i => i.CoverAmount == 100000), Gender = "M" },
                new Customer { FirstName = "Douglas", LastName = "Adams", SelectedInsurance = context.Insurances.Single(i => i.CoverAmount == 5000), Gender = "M" }
                );
            context.SaveChanges();
        }
    }
}
