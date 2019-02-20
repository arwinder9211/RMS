using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RMS.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        public int PostalCode { get; set; }

        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
