using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyCalculator.API.Entities
{
    public class UserRole : BaseEntity
    {
        [Required]
        public Guid UserId { get; set; }
        
        public User User { get; set; }

        [Required]
        public Guid RoleId { get; set; }

        public Role Role { get; set; }
    }
}
