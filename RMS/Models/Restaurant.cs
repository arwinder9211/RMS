using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RMS.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Cuisine")]
        public string Type { get; set; }

        public List<Dish> Dishes { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
