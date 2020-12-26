using Microsoft.AspNetCore.Mvc;
using Moq;
using ShoppingSystem.Controllers;
using ShoppingSystem.Models;
using ShoppingSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ShoppingSystem.Test.ControllersTest
{
    public class ProductsControllerTests
    {
        private readonly Mock<IProducts> _mockProducts = new Mock<IProducts>();

        private readonly int _idProductValide = 1;

        private readonly int _idProductNotValide = 7;

        private readonly List<Product> _productsListTest = new List<Product>()
        {
            new Product { Id = 1, Name = "ProductOne", Price = 9.99F },
            new Product { Id = 2, Name = "ProductSecond", Price = 19.99F },
            new Product { Id = 3, Name = "ProductThird", Price = 29.99F }

        };

        private readonly Product _newProductTest = new Product() { Id = 4, Name = "ProductFour", Price = 29.99F };

        private readonly Product _validProductTest = new Product() { Id = 1, Name = "ProductOne", Price = 9.99F };

        [Fact]
        public async Task Index_Return_List_Products()
        {
            //Arrange
            _mockProducts.Setup(x => x.GetAllAsync()).ReturnsAsync(_productsListTest);
            var productsController = new ProductsController(_mockProducts.Object);

            //Act
            var action = await productsController.Index();

            //Assert
            var actionModel = Assert.IsType<ViewResult>(action);
            Assert.Equal(_productsListTest, actionModel.Model);
        }

        [Fact]
        public async Task Details_Return_Product()
        {
            //Arrange            
            _mockProducts.Setup(x => x.GetByIdAsync(_idProductValide)).ReturnsAsync(_productsListTest.FirstOrDefault(x => x.Id == _idProductValide));
            var productsController = new ProductsController(_mockProducts.Object);

            //Act
            var action = await productsController.Details(_idProductValide);

            //Assert
            var actionView = Assert.IsType<ViewResult>(action);
            var actionModel = Assert.IsType<Product>(actionView.Model);
            Assert.Equal(_idProductValide, actionModel.Id);
            Assert.Equal(_productsListTest.Find(x => x.Id == actionModel.Id).Name, actionModel.Name);
            Assert.Equal(_productsListTest.Find(x => x.Id == actionModel.Id).Price, actionModel.Price);
        }

        [Fact]
        public async Task Details_Return_BadRequest()
        {
            //Arrange            
            _mockProducts.Setup(x => x.GetByIdAsync(_idProductNotValide)).Throws(new Exception());
            var productsController = new ProductsController(_mockProducts.Object);

            //Act
            var action = await productsController.Details(_idProductNotValide);

            //Assert
            var actionBadRequest = Assert.IsType<BadRequestResult>(action);
            Assert.Equal(400, actionBadRequest.StatusCode);
        }
 
        [Fact]
        public void Create_Get()
        {
            var productsController = new ProductsController(_mockProducts.Object);

            var action = productsController.Create();

            Assert.IsType<ViewResult>(action);
        }

        [Fact]
        public async Task Create_Post_New_and_Add_Product()
        {
            //Arrange            
            _mockProducts.Setup(x => x.AddAsync(null)).ThrowsAsync(new Exception());
            var productsController = new ProductsController(_mockProducts.Object);

            //Act
            var actionValide = await productsController.Create(_newProductTest);
            var actionNotValide = await productsController.Create(null);

            //Assert         
            var actionRedirect = Assert.IsType<RedirectToActionResult>(actionValide);
            Assert.Equal("Index", actionRedirect.ActionName);
            _mockProducts.Verify(x => x.AddAsync(_newProductTest));
            Assert.IsType<ViewResult>(actionNotValide);
        }

        [Fact]
        public async Task Edit_Get_Return_Product()
        {
            //Arrange            
            _mockProducts.Setup(x => x.GetByIdAsync(_idProductValide)).ReturnsAsync(_productsListTest.FirstOrDefault(x => x.Id == _idProductValide));
            var productsController = new ProductsController(_mockProducts.Object);

            //Act
            var action = await productsController.Edit(_idProductValide);

            //Assert
            var actionView = Assert.IsType<ViewResult>(action);
            var actionModel = Assert.IsType<Product>(actionView.Model);
            Assert.Equal(_idProductValide, actionModel.Id);
            Assert.Equal(_productsListTest.Find(x => x.Id == actionModel.Id).Name, actionModel.Name);
            Assert.Equal(_productsListTest.Find(x => x.Id == actionModel.Id).Price, actionModel.Price);
        }
    
        [Fact]
        public async Task Edit_Get_Return_BadRequest()
        {
            //Arrange            
            _mockProducts.Setup(x => x.GetByIdAsync(_idProductNotValide)).Throws(new Exception());
            var productsController = new ProductsController(_mockProducts.Object);

            //Act
            var action = await productsController.Edit(_idProductNotValide);

            //Assert
            var actionBadRequest = Assert.IsType<BadRequestResult>(action);
            Assert.Equal(400, actionBadRequest.StatusCode);
        }

        [Fact]
        public async Task Edit_Post_Product()
        {
            //Arrange   
            _mockProducts.Setup(x => x.EditAsync(_validProductTest));
            var productsController = new ProductsController(_mockProducts.Object);

            //Act
            var action = await productsController.Edit(_idProductValide, _validProductTest);

            //Assert         
            Assert.IsType<RedirectToActionResult>(action);
            _mockProducts.Verify(x => x.EditAsync(_validProductTest));
        }

        [Fact]
        public async Task Edit_Post_Return_BadRequest()
        {
            //Arrange            
            _mockProducts.Setup(x => x.EditAsync(_newProductTest)).Throws(new Exception());
            var productsController = new ProductsController(_mockProducts.Object);

            //Act
            var action = await productsController.Edit(_newProductTest.Id, _newProductTest);

            //Assert
            var actionBadRequest = Assert.IsType<BadRequestResult>(action);
            Assert.Equal(400, actionBadRequest.StatusCode);
        }      

        [Fact]
        public async Task Delete_Get()
        {
            //Arrange 
            _mockProducts.Setup(x => x.DeleteAsync(_idProductValide)).Verifiable();
            _mockProducts.Setup(x => x.DeleteAsync(_idProductNotValide)).Throws(new Exception());
            var productsController = new ProductsController(_mockProducts.Object);

            //Act            
            var actionValide = await productsController.Delete(_idProductValide);
            var actionNotValide = await productsController.Delete(_idProductNotValide);

            //Assert
            Assert.IsType<ViewResult>(actionNotValide);
            Assert.IsType<RedirectToActionResult>(actionValide);
            _mockProducts.Verify(x => x.DeleteAsync(_idProductValide));
        }

        [Fact]
        public async Task Delete_Post()
        {
            //Arrange     
            _mockProducts.Setup(x => x.DeleteAsync(_idProductValide));
            _mockProducts.Setup(x => x.DeleteAsync(_idProductNotValide)).Throws(new Exception());
            var productsController = new ProductsController(_mockProducts.Object);

            //Act
            var actionValide = await productsController.DeleteConfirmed(_idProductValide);
            var actionNotValide = await productsController.DeleteConfirmed(_idProductNotValide);

            //Assert
            Assert.IsType<ViewResult>(actionNotValide);
            Assert.IsType<RedirectToActionResult>(actionValide);
            _mockProducts.Verify(x => x.DeleteAsync(_idProductValide));
        }     
    }
}
