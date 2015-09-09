using System.Threading.Tasks;
using Abp.Application.Services;
using Insurance.Insurances.Dtos;

namespace Insurance.Insurances
{
    public interface IInsuranceAppService : IApplicationService
    {
        Task<GetAllInsurancesOutput> GetAllInsurances();
    }
}
