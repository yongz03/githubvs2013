using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Abp.EntityFramework;
using Insurance.Customers;

namespace Insurance.EntityFramework.Repositories
{
    public class CustomerRepository : InsuranceRepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDbContextProvider<InsuranceDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public List<Customer> GetAllWithInsurance(int? selectedInsuranceId)
        {
            var query = GetAll();

            if (selectedInsuranceId.HasValue)
            {
                query = query.Where(c => c.SelectedInsuranceId == selectedInsuranceId.Value);
            }

            return query.Include(c => c.SelectedInsurance).ToList();
        }

        public Customer GetByUserName(string firstName, string lastName, string title)
        {
            Guard.NotNullOrEmpty(() => firstName, firstName);
            Guard.NotNullOrEmpty(() => lastName, lastName);
            title = string.IsNullOrEmpty(title) ? string.Empty : title;

            return
                GetAll().FirstOrDefault(c => 
                    c.FirstName == firstName && 
                    c.LastName == lastName && 
                    c.Title == title);
        }
    }
}
