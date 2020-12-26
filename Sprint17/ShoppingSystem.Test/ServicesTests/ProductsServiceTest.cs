using Moq;
using ShoppingSystem.Data;
using ShoppingSystem.Models;
using ShoppingSystem.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ShoppingSystem.Test.ServicesTests
{
    public class ProductsServiceTest
    {
        Product _product = new Product() { Id = 1, Name = "Name", Price = 10F };
        private readonly List<Product> _products = new List<Product>()
        {
            new Product() {Id = 1, Name = "Product1", Price = 3F }
        };

        //[Fact]
        //public void AddAsync()
        //{
        //    //IDbContextGenerator contextGenerator;

        //    var dbSet = new Mock<DbSet<Product>>();
        //    dbSet.As<IQueryable<Product>>().Setup(x => x.Provider).Returns(_products.AsQueryable().Provider);
        //    dbSet.As<IQueryable<Product>>().Setup(x => x.Expression).Returns(_products.AsQueryable().Expression);
        //    dbSet.As<IQueryable<Product>>().Setup(x => x.ElementType).Returns(_products.AsQueryable().ElementType);
        //    dbSet.As<IQueryable<Product>>().Setup(x => x.GetEnumerator()).Returns(_products.AsQueryable().GetEnumerator());
        //    dbSet.Setup(x => x.Add(It.IsAny<Product>())).Callback<Product>((entity) => _products.Add(entity));

        //    var mockContext = new Mock<ShoppingContext>();
        //    //mockContext.Setup(x => x.Products.Add(It.IsAny<Product>())).Verifiable();

        //    mockContext.Setup(x => x.Add(It.IsAny<Product>())).Verifiable();
        //    mockContext.Setup(x => x.SaveChanges()).Returns(dbSet.Object.Count);

        //    var productService = new ProductsService(mockContext.Object);

        //    var action = productService.AddAsync(_product);
        //    var actionR = productService.GetAllAsync();

        //    Assert.Equal(_products.Count() + 1, actionR.Result.Count);
        //    //var productService = new ProductsService(mockContext.Object);

        //    //var action = productService.AddAsync(_product);

        //    mockContext.Verify(x => x.SaveChanges()); 
        //}
    }
}
