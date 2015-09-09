using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;

namespace Insurance.Customers.Dtos
{
    public class UpdateCustomerInput : IInputDto, ICustomValidate
    {
        [Range(1, int.MaxValue)] //Data annotation attributes work as expected.
        public int CustomerId { get; set; }

        public int? SelectedInsuranceId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool? Smoking { get; set; }
        public decimal CoverAmount { get; set; }
        public decimal Premium { get; set; }

        //Custom validation method. It's called by ABP after data annotation validations.
        public void AddValidationErrors(List<ValidationResult> results)
        {
            if (SelectedInsuranceId == null)
            {
                results.Add(new ValidationResult("SelectedInsuranceId can not be null in order to update a Customer!", new[] {"SelectedInsuranceId"}));
            }
        }
    }
}
