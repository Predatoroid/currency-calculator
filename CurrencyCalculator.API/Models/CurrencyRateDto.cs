using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyCalculator.API.Models
{
    public class CurrencyRateDto
    {
        public Guid Id { get; set; }
        public Guid BaseCurrencyId { get; set; }
        public string BaseCurrencyCode { get; set; }
        public Guid TargetCurrencyId { get; set; }
        public string TargetCurrencyCode { get; set; }
        public decimal Value { get; set; }
        public bool IsActive { get; set; }
    }
}
