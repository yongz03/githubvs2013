using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace Insurance.Customers.Dtos
{
    public class GetCustomersOutput : IOutputDto
    {
        public List<CustomerDto> Customers { get; set; }
    }
}
