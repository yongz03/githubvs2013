using System.ComponentModel.DataAnnotations;

namespace Insurance.Insurances
{
    public class ProtectInsurance : Insurance
    {
        [Range(1000, 5000)]
        public override decimal CoverAmount { get; set; }
    }
}
