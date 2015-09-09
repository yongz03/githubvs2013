using System.Collections.Generic;
using Abp.Domain.Repositories;

namespace Insurance.Customers
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        List<Customer> GetAllWithInsurance(int? selectedInsuranceId);
        Customer GetByUserName(string firstName, string lastName, string title);
    }
}
