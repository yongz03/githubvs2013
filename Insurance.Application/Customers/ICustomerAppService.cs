using System.Threading.Tasks;
using Abp.Application.Services;
using Insurance.Customers.Dtos;

namespace Insurance.Customers
{
    public interface ICustomerAppService : IApplicationService
    {
        Task<GetCustomersOutput> GetCustomers();
        GetCustomersOutput GetCustomers(GetCustomersInput input);
        CustomerDto GetCustomer(UpdateCustomerInput input);
        void UpdateCustomer(UpdateCustomerInput input);
        void CreateCustomer(CreateCustomerInput input);
    }
}
