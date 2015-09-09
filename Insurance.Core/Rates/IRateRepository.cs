using System.Collections.Generic;

namespace Insurance.Rates
{
    public interface IRateRepository
    {
        List<Rate> GetAllRates();
    }
}
