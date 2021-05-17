using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyCalculator.API.Models
{
    public class CurrencyRateForCreationDto
    {
        public string BaseCurrencyCode { get; set; }
        public string TargetCurrencyCode { get; set; }
        public decimal Value { get; set; }
    }
}
