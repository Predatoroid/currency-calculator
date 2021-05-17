using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyCalculator.API.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public DateTimeOffset DatetimeCreated { get; set; }

        public DateTimeOffset DatetimeUpdated { get; set; }

        public bool IsActive { get; set; }
    }
}
