using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProductsValidation.Models
{
    public class Product
    {
        public enum Category
        {
            [Display(Name = "Category not assigned")]
            Select,

            [Display(Name = "Toy")]
            Toy,

            [Display(Name = "Technique")]
            Technique,

            [Display(Name = "Clothes")]
            Clothes,

            [Display(Name = "Transport")]
            Transport
        }

        public int Id { get; set; }

        [Display(Name = "Category")]
        [Remote("ValidateCategoryProduct", "Products")]
        public Category Type { get; set; }

        [Required]
        public string Name { get; set; }

        [Remote("ValidateDescriptionProduct", "Products", AdditionalFields = nameof(Name))]
        public string Description { get; set; }
        
        [Range(0, 100000)]
        public decimal Price { get; set; }
    }
}
