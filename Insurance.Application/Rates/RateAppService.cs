using System.Collections.Generic;
using Abp.Application.Services;
using AutoMapper;
using Insurance.Rates.Dtos;

namespace Insurance.Rates
{
    public class RateAppService : ApplicationService, IRateAppService
    {
        //These members set in constructor using constructor injection.

        private readonly IRateRepository _rateRepository;

        /// <summary>
        ///In constructor, we can get needed classes/interfaces.
        ///They are sent here by dependency injection system automatically.
        /// </summary>
        public RateAppService(IRateRepository rateRepository)
        {
            _rateRepository = rateRepository;
        }

        public GetRatesOutput GetAllRates()
        {
            var rates = _rateRepository.GetAllRates();

            return new GetRatesOutput
            {
                Rates=Mapper.Map<List<RateDto>>(rates)
            };
        }

    }
}
