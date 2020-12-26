using Microsoft.AspNetCore.Mvc;
using Moq;
using ShoppingSystem.Controllers;
using ShoppingSystem.Models;
using ShoppingSystem.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ShoppingSystem.Test.ControllersTests
{
    public class ProductsControllerTest
    {


        [Fact]
        public async Task Index()
        {
            var mockProducts = new Mock<IProducts>();

            var productsListTest = new List<Product>()
            {
                new Product { Id = 1, Name = "ProductOne", Price = 9.99F },
                new Product { Id = 2, Name = "ProductSecond", Price = 19.99F },
                new Product { Id = 3, Name ="ProductThird", Price = 29.99F }
            };
            //Arrange
            mockProducts.Setup(x => x.GetAllAsync()).ReturnsAsync(productsListTest);
            var productController = new ProductsController(mockProducts.Object);

            //Act

            var result = await productController.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(productsListTest, viewResult.Model);
        }
    }
}
