using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskShoppingSystemEF.Models
{
    public class Customer
    {
        public enum Discount
        {
            [Display(Name = "Discount not assigned")]
            Select = 0,

            [Display(Name = "A")]
            A = 5,

            [Display(Name = "B")]
            B = 10,

            [Display(Name = "C")]
            C = 15
        }

        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required]
        [StringLength(50, ErrorMessage = "First Name length can't be more than 50.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [StringLength(50, ErrorMessage = "Last Name length can't be more than 50.")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Address length can't be more than 50.")]
        public string Address { get; set; }

        [Display(Name = "Grade Discount")]
        public Discount GradeDiscount { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }

        public List<Order> Orders { get; set; }
    }
}
