using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using AutoMapper;
using Insurance.Customers.Dtos;
using Insurance.Insurances;

namespace Insurance.Customers
{
    public class CustomerAppService : ApplicationService, ICustomerAppService
{
    //These members set in constructor using constructor injection.
        
    private readonly ICustomerRepository _customerRepository;
    private readonly IRepository<Insurances.Insurance> _insuranceRepository;
        
    /// <summary>
    ///In constructor, we can get needed classes/interfaces.
    ///They are sent here by dependency injection system automatically.
    /// </summary>
    public CustomerAppService(ICustomerRepository customerRepository, IRepository<Insurances.Insurance> insuranceRepository)
    {
        _customerRepository = customerRepository;
        _insuranceRepository = insuranceRepository;
    }

    public async Task<GetCustomersOutput> GetCustomers()
    {
        //Called specific GetAllAsync method of Customer repository.
        var customers = await _customerRepository.GetAllListAsync();

        //Used AutoMapper to automatically convert List<Customer> to List<CustomerDto>.
        return new GetCustomersOutput
        {
            Customers = Mapper.Map<List<CustomerDto>>(customers)
        };

    }

    public GetCustomersOutput GetCustomers(GetCustomersInput input)
    {
        //Called specific GetAllWithInsurance method of Customer repository.
        var customers = _customerRepository.GetAllWithInsurance(input.SelectedInsuranceId);

        //Used AutoMapper to automatically convert List<Customer> to List<CustomerDto>.
        return new GetCustomersOutput
                {
                    Customers = customers.MapTo<List<CustomerDto>>()
                };
    }

    public CustomerDto GetCustomer(UpdateCustomerInput input)
    {
        var customer = _customerRepository.GetByUserName(input.FirstName, input.LastName, input.Title);

        return Mapper.Map<CustomerDto>(customer);
    }

    public void UpdateCustomer(UpdateCustomerInput input)
    {
        //We can use Logger, it's defined in ApplicationService base class.
        Logger.Info("Updating a Customer for input: " + input);

        //Retrieving a Customer entity with given id using standard Get method of repositories.
        var customer = _customerRepository.Get(input.CustomerId);
        customer.Title = input.Title;
        customer.FirstName = input.FirstName;
        customer.LastName = input.LastName;
        customer.Gender = input.Gender;
        customer.DateOfBirth = input.DateOfBirth;
        customer.Smoking = input.Smoking;

        //Updating changed properties of the retrieved Customer entity.

        if (input.SelectedInsuranceId.HasValue)
        {
            customer.SelectedInsurance = _insuranceRepository.Load(input.SelectedInsuranceId.Value);
            customer.SelectedInsurance.CoverAmount = input.CoverAmount;
            customer.SelectedInsurance.Premium = input.Premium;
        }

        //We even do not call Update method of the repository.
        //Because an application service method is a 'unit of work' scope as default.
        //ABP automatically saves all changes when a 'unit of work' scope ends (without any exception).
    }

    public void CreateCustomer(CreateCustomerInput input)
    {
        //We can use Logger, it's defined in ApplicationService class.
        Logger.Info("Creating a Customer for input: " + input);

        //Creating a new Customer entity with given input's properties
        var customer = new Customer
        {
            Gender = input.Gender,
            DateOfBirth = input.DateOfBirth,
            Smoking = input.Smoking,
            Title = input.Title,
            FirstName = input.FirstName,
            LastName = input.LastName
        };

        if (input.SelectedInsuranceId.HasValue)
        {
            customer.SelectedInsuranceId = input.SelectedInsuranceId;
            customer.SelectedInsurance = _insuranceRepository.Load(input.SelectedInsuranceId.Value);
            customer.SelectedInsurance.CoverAmount = input.CoverAmount;
            customer.SelectedInsurance.Premium = input.Premium;

        }
        else
        {
            if (input.IsProtect)
            {
                var protect = new ProtectInsurance();
                protect.CoverAmount = input.CoverAmount;
                protect.Premium = input.Premium;
                customer.SelectedInsurance = protect;

            }
            else
            {
                var life = new LifeInsurance();
                life.CoverAmount = input.CoverAmount;
                life.Premium = input.Premium;
                customer.SelectedInsurance = life;
            }
            
        }

        //Saving entity with standard Insert method of repositories.
        _customerRepository.Insert(customer);
    }
}
}
