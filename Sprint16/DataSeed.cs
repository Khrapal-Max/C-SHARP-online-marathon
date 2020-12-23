using System.Linq;
using TaskShoppingSystemEF.Data;
using TaskShoppingSystemEF.Models;

namespace TaskShoppingSystemEF
{
    public class DataSeed
    {
        public static void Initialize(ShoppingSystemContext context)
        {
            if (context.Customers.Any()) 
            {
                return;
            }

            var customers = new Customer[]
            {
                new Customer{FirstName = "Carson", LastName="Alexander", Address = "Dnipro", GradeDiscount = Customer.Discount.A},
                new Customer{FirstName = "Meredith", LastName="Alonso", Address = "Lviv", GradeDiscount = Customer.Discount.B},
                new Customer{FirstName = "Arturo", LastName="Anand", Address = "Kiev", GradeDiscount = Customer.Discount.C},
                new Customer{FirstName = "Gytis", LastName="Barzdukas", Address = "Dnipro", GradeDiscount = Customer.Discount.B},
                new Customer{FirstName = "Peggy", LastName="Justice", Address = "Zaporizhzhia", GradeDiscount = Customer.Discount.A},
                new Customer{FirstName = "Laura", LastName="Norman", Address = "Zaporizhzhia" }
            };

            foreach (var customer in customers)
            {
                context.Customers.Add(customer);
            }
            context.SaveChanges();

            var superMarkets = new Supermarket[]
            {
                new Supermarket{ Name = "Billa" , Address = "Dnipro" },
                new Supermarket{ Name = "ATB" , Address = "Zaporizhzhia" },
                new Supermarket{ Name = "Varus" , Address = "Lviv" },
                new Supermarket{ Name = "Metro" , Address = "Kiev" }
            };

            foreach (var supermarket in superMarkets)
            {
                context.Supermarkets.Add(supermarket);
            }
            context.SaveChanges();

            var products = new Product[]
            {
                new Product{ Name = "Banana", Price = 9.99F },
                new Product{ Name = "Pepsi", Price = 14.99F },
                new Product{ Name = "Cola", Price = 13.99F },
                new Product{ Name = "Fanta", Price = 16.99F },
                new Product{ Name = "Chocolate", Price = 29.99F },
                new Product{ Name = "Bread", Price = 12.99F }
            };

            foreach (var product in products)
            {
                context.Products.Add(product);
            }
            context.SaveChanges();
        }
    }
}
