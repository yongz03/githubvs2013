using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Insurance.Customers.Dtos
{
    [AutoMapFrom(typeof(Customer))]
    public class CustomerDto : EntityDto
    {
        public int? SelectedInsuranceId { get; set; }
        public Insurances.Insurance SelectedInsurance { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual string Gender { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual bool? Smoking { get; set; }
    }
}
