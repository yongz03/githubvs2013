using AutoMapper;
using Insurance.Customers;
using Insurance.Customers.Dtos;
using Insurance.Insurances.Dtos;
using Insurance.Rates;
using Insurance.Rates.Dtos;

namespace Insurance.Application
{
    internal static class DtoMappings
    {
        public static void Map()
        {
            Mapper.CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.SelectedInsuranceId, option => option.MapFrom(src => src.SelectedInsuranceId)).ReverseMap();
            
            Mapper.CreateMap<Insurances.Insurance, InsuranceDto>();
            Mapper.CreateMap<Insurances.LifeInsurance, LifeInsuranceDto>();
            Mapper.CreateMap<Insurances.ProtectInsurance, ProtectInsuranceDto>();

            Mapper.CreateMap<Rate, RateDto>();
        }
    }
}
