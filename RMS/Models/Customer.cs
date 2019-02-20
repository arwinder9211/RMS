using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RMS.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Sex { get; set; }

        [Required]
        public string City { get; set; }

        public bool IsActive { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
