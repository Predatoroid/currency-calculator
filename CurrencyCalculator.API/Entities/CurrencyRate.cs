using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyCalculator.API.Entities
{
    public class CurrencyRate : BaseEntity
    {
        [ForeignKey("BaseCurrencyId")]
        public Currency BaseCurrency { get; set; }

        public Guid BaseCurrencyId { get; set; }

        [ForeignKey("TargetCurrencyId")]
        public Currency TargetCurrency { get; set; }

        public Guid TargetCurrencyId { get; set; }


        [Column(TypeName = "decimal(19,6)")]
        public decimal Value { get; set; }
    }
}
