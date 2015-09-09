using System.Collections.Generic;
using Abp.Configuration;
using Insurance.Rates;
using Newtonsoft.Json;

namespace Insurance.Web
{
    public class InsuranceRatesProvider : SettingProvider
    {
        private readonly IRateAppService _rateAppService;

        public InsuranceRatesProvider(IRateAppService rateAppService)
        {
            _rateAppService = rateAppService;
        }

        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            var rates = _rateAppService.GetAllRates();

            var ratesStringified = JsonConvert.SerializeObject(rates, MvcApplication.JsonSerializerSettings);
            return new[]
            {
                new SettingDefinition(
                    "Rates",
                    ratesStringified,
                    isVisibleToClients: true
                    )

            };
        }
    }
}