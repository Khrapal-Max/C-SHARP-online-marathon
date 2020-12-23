using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskShoppingSystemEF.Models;

namespace TaskShoppingSystemEF.Data
{
    public class ShoppingSystemContext : DbContext
    {
        public ShoppingSystemContext(DbContextOptions<ShoppingSystemContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Supermarket> Supermarkets { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
