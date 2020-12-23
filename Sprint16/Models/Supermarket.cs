using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskShoppingSystemEF.Models
{
    public class Supermarket
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name market length can't be more than 50.")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Address market length can't be more than 100.")]
        public string Address { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return Name + " " + Address;
            }
        }

        public List<Order> Orders { get; set; }
    }
}
