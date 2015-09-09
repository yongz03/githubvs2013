using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace Insurance.Customers
{
    [Table("Customers", Schema = "TAL")]
    public class Customer : Entity
    {
        public string Title { get; set; }
        [Required, StringLength(50)]
        public string FirstName { get; set; }
        [Required, StringLength(50)]
        public string LastName { get; set; }
        [Column(Order = 2)]
        [Required]
        public virtual string Gender { get; set; }
        [Required, Column(Order = 3)]
        public virtual DateTime DateOfBirth { get; set; }
        [Column(Order = 100)]
        public virtual bool? Smoking { get; set; }
        [ForeignKey("SelectedInsuranceId")]
        public virtual Insurance.Insurances.Insurance SelectedInsurance { get; set; }
        public virtual int? SelectedInsuranceId { get; set; }

    }
}
