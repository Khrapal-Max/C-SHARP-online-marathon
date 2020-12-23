using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskShoppingSystemEF.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name product length can't be more than 50.")]
        public string Name { get; set; }

        [Required]
        [Range(0.01, 10000)]
        public float Price { get; set; }

        public List<OrderDetails> OrderDetails { get; set; }
    }
}
