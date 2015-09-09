using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace Insurance.Rates.Dtos
{
    public class GetRatesOutput:IOutputDto
    {
        public List<RateDto> Rates { get; set; } 
    }
}
