using System;
using System.Collections.Generic;
using System.Linq;
//Please create a method TotalPrice(ILookup<string, Product> lookup) in which print(Name + " " + Price) 
//from one category and total price for products from these categories (Key + " " + totalPriceForCategory)
namespace Level01Task01
{
    class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            {
                var products = new List<Product>();
                products.Add(new Product { Name = "SmartTV", Price = 400, Category = "Electronics" });
                products.Add(new Product { Name = "Lenovo ThinkPad", Price = 1000, Category = "Electronics" });
                products.Add(new Product { Name = "Iphone", Price = 700, Category = "Electronics" });
                products.Add(new Product { Name = "Orange", Price = 2, Category = "Fruits" });
                products.Add(new Product { Name = "Banana", Price = 3, Category = "Fruits" });
                ILookup<string, Product> lookup = products.ToLookup(prod => prod.Category);
                TotalPrice(lookup);
                Console.ReadKey();
            }
            Console.WriteLine("Hello World!");
        }
        private static void TotalPrice(ILookup<string, Product> lookup)
        {
            foreach (var group in lookup)
            {
                foreach (var item in group)
                {
                    Console.WriteLine(item.Name + " " + item.Price);
                }
                Console.WriteLine(group.Key + " " + group.Sum(x => x.Price));
            }
        }
    }
}
