using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyCalculator.API.Models
{
    public class CurrencyForCreationDto
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
