using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RMS.Models
{
    /// <summary>
    /// Restaurant with address view model class 
    /// </summary>
    public class RestaurantViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Cuisine")]
        public string Type { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        public int PostalCode { get; set; }

        public int AddressId { get; set; }
        public int Id { get; set; }
    }
}
