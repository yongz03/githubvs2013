using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Insurance.Attributes;

namespace Insurance.Insurances
{
    [Table("Insurances", Schema = "TAL")]
    public class Insurance : Entity, IHasCreationTime, IModificationAudited
    {
        [Required, Column(Order = 2), DecimalPrecision(6, 0)]
        public virtual decimal CoverAmount { get; set; }
        [Column(Order = 3), DecimalPrecision(7, 2)]
        public virtual decimal Premium { get; set; }
        public virtual DateTime CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
    }
}
