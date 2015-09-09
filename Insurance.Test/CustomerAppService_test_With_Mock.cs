using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Insurance.Customers;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace Insurance.Test
{
    /// <summary>
    /// Alternative test to PersonAppService_Tests
    /// that uses NSubstitute for mocking person repository.
    /// </summary>
    [TestFixture]
    public class CustomerAppService_Tests_With_Mocks : InsuranceTestBase
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerAppService_Tests_With_Mocks()
        {
            //Fake repository will contain 2 people
            var customers = new List<Customer>
                         {
                             new Customer {FirstName = "John", LastName = "Nash"},
                             new Customer {FirstName = "Forrest", LastName = "Gump"}
                         };

            //Create the fake person repository
            var customerRepository = new Mock<ICustomerRepository>();
            var insuranceRepository = new Mock<IRepository<Insurances.Insurance>>();

            //Arrange GetAll() method to return the list above
            customerRepository.Setup(client => client.GetAllListAsync()).Returns(Task.FromResult(customers));

            //Create PersonAppService by providing the fake repository
            _customerAppService = new CustomerAppService(customerRepository.Object, insuranceRepository.Object);
        }

        [Test]
        public async Task Should_Get_All_Customers()
        {
            //Run testing method
            var output = await _customerAppService.GetCustomers();

            //Check results
            output.Customers.Count.ShouldBe(2);
            output.Customers.FirstOrDefault(p => p.FirstName == "John" && p.LastName == "Nash").ShouldNotBe(null);
        }
    }
}
