using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Runtime.Validation;
using Insurance.Customers;
using Insurance.Customers.Dtos;
using NUnit.Framework;
using Shouldly;

namespace Insurance.Test
{
    [TestFixture]
    public class CustomerAppService_Tests : InsuranceTestBase
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerAppService_Tests()
        {
            //Creating the class which is tested (SUT - Software Under Test)
            _customerAppService = LocalIocManager.Resolve<ICustomerAppService>();
        }

        [Test]
        public void Should_Create_New_Customers()
        {
            //Prepare for test
            var initialCustomerCount = UsingDbContext(context => context.Customers.Count());
            var thomasMore = GetCustomer("Thomas", "More");

            //Run SUT
            _customerAppService.CreateCustomer(
                new CreateCustomerInput
                {
                    FirstName = "my test1",
                    LastName = "Customer 1",
                    CoverAmount = 10000,
                    DateOfBirth = new DateTime(1972, 2, 20),
                    Gender = "M",
                    IsProtect = false,
                    Premium = (decimal) 0.58
                });
            _customerAppService.CreateCustomer(
                new CreateCustomerInput
                {
                    FirstName = "my test2",
                    LastName = "Customer 2",
                    SelectedInsuranceId = thomasMore.SelectedInsuranceId,
                    CoverAmount = 100000,
                    DateOfBirth = new DateTime(1962, 2, 20),
                    Gender = "F",
                    IsProtect = true,
                    Premium = (decimal)0.30
                });

            //Check results
            UsingDbContext(context =>
            {
                context.Customers.Count().ShouldBe(initialCustomerCount + 2);
                var customer1 = context.Customers.FirstOrDefault(c => c.FirstName == "my test1" && c.LastName == "Customer 1");
                customer1.ShouldNotBe(null);
                customer1.SelectedInsuranceId.ShouldBe(5);
                var Customer2 = context.Customers.FirstOrDefault(c => c.FirstName == "my test2" && c.LastName == "Customer 2");
                Customer2.ShouldNotBe(null);
                Customer2.SelectedInsuranceId.ShouldBe(thomasMore.Id);
            });
        }

        [Test]
        public void Should_Not_Create_Task_Without_Description()
        {
            //Create customer input is not set
            Assert.Throws<AbpValidationException>(() => _customerAppService.CreateCustomer(new CreateCustomerInput()));
        }

        [Test]
        public void Should_Change_Assigned_Insurance()
        {
            //We can work with repositories instead of DbContext
            var customerRepository = LocalIocManager.Resolve<ICustomerRepository>();

            //Obtain test data
            var isaacAsimov = GetCustomer("Isaac","Asimov");
            var thomasMore = GetCustomer("Thomas", "More");
            var targetCustomer = customerRepository.GetAllWithInsurance(isaacAsimov.SelectedInsuranceId).FirstOrDefault();
            targetCustomer.ShouldNotBe(null);

            //Run SUT
            _customerAppService.UpdateCustomer(
                new UpdateCustomerInput
                {
                    CustomerId = targetCustomer.Id,
                    SelectedInsuranceId = thomasMore.SelectedInsuranceId,
                    CoverAmount = targetCustomer.SelectedInsurance.CoverAmount,
                    DateOfBirth = targetCustomer.DateOfBirth,
                    FirstName = targetCustomer.FirstName,
                    LastName = targetCustomer.LastName,
                    Gender = targetCustomer.Gender,
                    Premium = targetCustomer.SelectedInsurance.Premium,
                    Smoking = targetCustomer.Smoking,
                    Title = targetCustomer.Title
                });

            //Check result
            customerRepository.Get(targetCustomer.Id).SelectedInsuranceId.ShouldBe(thomasMore.Id);

        }

        [Test]
        public async Task Should_Get_All_Customers()
        {
            var output = await _customerAppService.GetCustomers();
            output.Customers.Count.ShouldBe(6);
        }

        [Test]
        public void Should_Get_All_Customers_WithInsurance()
        {
            var isaacAsimov = GetCustomer("Isaac","Asimov");

            var getCustomerInput = new GetCustomersInput()
            {
                SelectedInsuranceId =isaacAsimov.SelectedInsuranceId
            };

            var output = _customerAppService.GetCustomers(getCustomerInput);
            output.Customers.Count.ShouldBe(3);
        }

        private Customer GetCustomer(string firstName, string lastName)
        {
            return UsingDbContext(context => context.Customers.Single(p => p.FirstName == firstName && p.LastName==lastName));
        }
    }
}
