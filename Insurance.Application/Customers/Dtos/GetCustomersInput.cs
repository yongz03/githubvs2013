using Abp.Application.Services.Dto;

namespace Insurance.Customers.Dtos
{
    public class GetCustomersInput : IInputDto
    {
        public int? SelectedInsuranceId { get; set; }
    }
}
