using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace Insurance.Insurances.Dtos
{
    public class GetAllInsurancesOutput : IOutputDto
    {
        public List<InsuranceDto> Insurances { get; set; }
    }
}
