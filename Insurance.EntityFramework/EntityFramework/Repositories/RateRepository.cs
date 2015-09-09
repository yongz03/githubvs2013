using System.Collections.Generic;
using System.Linq;
using Abp.EntityFramework;
using Insurance.Rates;

namespace Insurance.EntityFramework.Repositories
{
    public class RateRepository : InsuranceRepositoryBase<Rate>, IRateRepository
    {
        public RateRepository(IDbContextProvider<InsuranceDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public List<Rate> GetAllRates()
        {
            return GetAll().ToList();
        } 
    }
}
