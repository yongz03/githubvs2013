using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Insurance.Insurances.Dtos
{
    [AutoMapFrom(typeof(Insurances.Insurance))] //AutoMapFrom attribute maps Insurance -> InsuranceDto
    public class InsuranceDto : EntityDto
    {
        public decimal CoverAmount { get; set; }
        public decimal Premium { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
