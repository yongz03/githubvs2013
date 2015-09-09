using System.ComponentModel.DataAnnotations;

namespace Insurance.Insurances
{
    public class LifeInsurance : Insurance
    {
        [Range(1000, 100000)]
        public override decimal CoverAmount { get; set; }
    }
}
