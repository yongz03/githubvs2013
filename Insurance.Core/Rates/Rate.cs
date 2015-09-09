using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Insurance.Attributes;

namespace Insurance.Rates
{
    [Table("Rates", Schema = "TAL")]
    public class Rate : Entity
    {
        public string Gender { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        [DecimalPrecision(4, 3)]
        public decimal PricePerThousandCover { get; set; }
        public bool Smoker { get; set; }
        public bool IsProtect { get; set; }
    }
}
