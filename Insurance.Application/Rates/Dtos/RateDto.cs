using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Insurance.Rates.Dtos
{
    [AutoMapFrom(typeof(Rate))]
    public class RateDto : EntityDto
    {
        public string Gender { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public decimal PricePerThousandCover { get; set; }
        public bool IsProtect { get; set; }
    }
}
