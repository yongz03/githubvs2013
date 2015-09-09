using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace Insurance.Customers.Dtos
{
    public class CreateCustomerInput : IInputDto
    {
        public int? SelectedInsuranceId { get; set; }
        public string Title { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public bool? Smoking { get; set; }
        public decimal Premium { get; set; }
        [Required]
        public decimal CoverAmount { get; set; }
        [Required]
        public bool IsProtect { get; set; }
        
    }
}
