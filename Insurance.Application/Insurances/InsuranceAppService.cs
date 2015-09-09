using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using AutoMapper;
using Insurance.Insurances.Dtos;

namespace Insurance.Insurances
{
    public class InsuranceAppService : IInsuranceAppService //Optionally, you can derive from ApplicationService as we did for TaskAppService class.
    {
        private readonly IRepository<Insurance> _insuranceRepository;

        //ABP provides that we can directly inject IRepository<Insurance> (without creating any repository class)
        public InsuranceAppService(IRepository<Insurance> insuranceRepository)
        {
            _insuranceRepository = insuranceRepository;
        }

        //This method uses async pattern that is supported by ASP.NET Boilerplate
        public async Task<GetAllInsurancesOutput> GetAllInsurances()
        {
            var insurances = await _insuranceRepository.GetAllListAsync();
            return new GetAllInsurancesOutput
            {
                Insurances = Mapper.Map<List<InsuranceDto>>(insurances)
            };
        }
    }
}
