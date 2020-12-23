using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskShoppingSystemEF.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        [Required]
        public int CustomerID { get; set; }

        [Display(Name = "Supermarket")]
        [Required]
        public int SupermarketID { get; set; }
       
        public Customer Customer { get; set; }

        public Supermarket Supermarket { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }
        
        public List<OrderDetails> OrderDetails { get; set; }
    }
}
