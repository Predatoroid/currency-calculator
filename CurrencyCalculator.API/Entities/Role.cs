using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyCalculator.API.Entities
{
    public class Role : BaseEntity
    {
        [Required]
        public string Description { get; set; }
    }
}
