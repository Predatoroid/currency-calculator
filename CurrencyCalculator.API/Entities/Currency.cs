using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CurrencyCalculator.API.Entities
{
    [Index(nameof(Code), IsUnique = true)]
    public class Currency : BaseEntity
    {
        [Required]
        [MaxLength(5)]
        public string Code { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
    }
}
