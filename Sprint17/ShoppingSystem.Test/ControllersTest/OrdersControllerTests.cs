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
    public class OrdersControllerTests
    {

        private readonly Mock<IOrders> _mockOrders = new Mock<IOrders>();

        private readonly int _idOrderValide = 1;

        private readonly int _idOrderNotValide = 7;

        private readonly List<Order> _ordersListTest = new List<Order>()
        {
            new Order () { Id = 1 },
        };

        private readonly Order _newOrderTest = new Order();

        private readonly Order _validOrderTest = new Order();


        [Fact]
        public async Task Index_Return_List_Products()
        {
            //Arrange
            _mockOrders.Setup(x => x.GetAllAsync()).ReturnsAsync(_ordersListTest);
            var ordersController = new OrdersController(_mockOrders.Object);

            //Act
            var action = await ordersController.Index();

            //Assert
            var actionModel = Assert.IsType<ViewResult>(action);
            Assert.Equal(_ordersListTest, actionModel.Model);
        }

        [Fact]
        public async Task Details_Return_Orders()
        {
            //Arrange            
            _mockOrders.Setup(x => x.GetByIdAsync(_idOrderValide)).ReturnsAsync(_ordersListTest.FirstOrDefault(x => x.Id == _idOrderValide));
            var ordersController = new OrdersController(_mockOrders.Object);

            //Act
            var action = await ordersController.Details(_idOrderValide);

            //Assert
            var actionView = Assert.IsType<ViewResult>(action);
            var actionModel = Assert.IsType<Order>(actionView.Model);
            Assert.Equal(_idOrderValide, actionModel.Id);
            Assert.Equal(_ordersListTest.Find(x => x.Id == actionModel.Id).OrderDate, actionModel.OrderDate);
            Assert.Equal(_ordersListTest.Find(x => x.Id == actionModel.Id).Customer, actionModel.Customer);
            Assert.Equal(_ordersListTest.Find(x => x.Id == actionModel.Id).CustomerId, actionModel.CustomerId);
            Assert.Equal(_ordersListTest.Find(x => x.Id == actionModel.Id).Supermarket, actionModel.Supermarket);
            Assert.Equal(_ordersListTest.Find(x => x.Id == actionModel.Id).SupermarketId, actionModel.SupermarketId);
        }

        [Fact]
        public async Task Details_Return_BadRequest()
        {
            //Arrange            
            _mockOrders.Setup(x => x.GetByIdAsync(_idOrderNotValide)).Throws(new Exception());
            var ordersController = new OrdersController(_mockOrders.Object);

            //Act
            var action = await ordersController.Details(_idOrderNotValide);

            //Assert
            var actionBadRequest = Assert.IsType<BadRequestResult>(action);
            Assert.Equal(400, actionBadRequest.StatusCode);
        }

        [Fact]
        public void Create_Get()
        {
            var ordersController = new OrdersController(_mockOrders.Object);

            var action = ordersController.Create();

            Assert.IsType<ViewResult>(action);
        }

        [Fact]
        public async Task Create_Post_New_and_Add_Order()
        {
            //Arrange            
            _mockOrders.Setup(x => x.AddAsync(null)).ThrowsAsync(new Exception());
            var ordersController = new OrdersController(_mockOrders.Object);

            //Act
            var actionValide = await ordersController.Create(_newOrderTest);
            var actionNotValide = await ordersController.Create(null);

            //Assert         
            var actionRedirect = Assert.IsType<RedirectToActionResult>(actionValide);
            Assert.Equal("Index", actionRedirect.ActionName);
            _mockOrders.Verify(x => x.AddAsync(_newOrderTest));
            Assert.IsType<ViewResult>(actionNotValide);
        }

        [Fact]
        public async Task Edit_Get_Return_Order()
        {
            //Arrange            
            _mockOrders.Setup(x => x.GetByIdAsync(_idOrderValide)).ReturnsAsync(_ordersListTest.FirstOrDefault(x => x.Id == _idOrderValide));
            var ordersController = new OrdersController(_mockOrders.Object);

            //Act
            var action = await ordersController.Edit(_idOrderValide);

            //Assert
            var actionView = Assert.IsType<ViewResult>(action);
            var actionModel = Assert.IsType<Order>(actionView.Model);
            Assert.Equal(_idOrderValide, actionModel.Id);
            Assert.Equal(_ordersListTest.Find(x => x.Id == actionModel.Id).OrderDate, actionModel.OrderDate);
            Assert.Equal(_ordersListTest.Find(x => x.Id == actionModel.Id).Customer, actionModel.Customer);
            Assert.Equal(_ordersListTest.Find(x => x.Id == actionModel.Id).CustomerId, actionModel.CustomerId);
            Assert.Equal(_ordersListTest.Find(x => x.Id == actionModel.Id).Supermarket, actionModel.Supermarket);
            Assert.Equal(_ordersListTest.Find(x => x.Id == actionModel.Id).SupermarketId, actionModel.SupermarketId);
        }

        [Fact]
        public async Task Edit_Get_Return_BadRequest()
        {
            //Arrange            
            _mockOrders.Setup(x => x.GetByIdAsync(_idOrderNotValide)).Throws(new Exception());
            var ordersController = new OrdersController(_mockOrders.Object);

            //Act
            var action = await ordersController.Edit(_idOrderNotValide);

            //Assert
            var actionBadRequest = Assert.IsType<BadRequestResult>(action);
            Assert.Equal(400, actionBadRequest.StatusCode);
        }

        [Fact]
        public async Task Edit_Post_Order()
        {
            //Arrange   
            _mockOrders.Setup(x => x.EditAsync(_validOrderTest));
            var ordersController = new OrdersController(_mockOrders.Object);

            //Act
            var action = await ordersController.Edit(_idOrderValide, _validOrderTest);

            //Assert         
            Assert.IsType<RedirectToActionResult>(action);
            _mockOrders.Verify(x => x.EditAsync(_validOrderTest));
        }

        [Fact]
        public async Task Edit_Post_Return_BadRequest()
        {
            //Arrange            
            _mockOrders.Setup(x => x.EditAsync(_newOrderTest)).Throws(new Exception());
            var ordersController = new OrdersController(_mockOrders.Object);

            //Act
            var action = await ordersController.Edit(_newOrderTest.Id, _newOrderTest);

            //Assert
            var actionBadRequest = Assert.IsType<BadRequestResult>(action);
            Assert.Equal(400, actionBadRequest.StatusCode);
        }

        [Fact]
        public async Task Delete_Get()
        {
            //Arrange 
            _mockOrders.Setup(x => x.DeleteAsync(_idOrderValide)).Verifiable();
            _mockOrders.Setup(x => x.DeleteAsync(_idOrderNotValide)).Throws(new Exception());
            var ordersController = new OrdersController(_mockOrders.Object);

            //Act            
            var actionValide = await ordersController.Delete(_idOrderValide);
            var actionNotValide = await ordersController.Delete(_idOrderNotValide);

            //Assert
            Assert.IsType<ViewResult>(actionNotValide);
            Assert.IsType<RedirectToActionResult>(actionValide);
            _mockOrders.Verify(x => x.DeleteAsync(_idOrderValide));
        }

        [Fact]
        public async Task Delete_Post()
        {
            //Arrange     
            _mockOrders.Setup(x => x.DeleteAsync(_idOrderValide));
            _mockOrders.Setup(x => x.DeleteAsync(_idOrderNotValide)).Throws(new Exception());
            var ordersController = new OrdersController(_mockOrders.Object);

            //Act
            var actionValide = await ordersController.DeleteConfirmed(_idOrderValide);
            var actionNotValide = await ordersController.DeleteConfirmed(_idOrderNotValide);

            //Assert
            Assert.IsType<ViewResult>(actionNotValide);
            Assert.IsType<RedirectToActionResult>(actionValide);
            _mockOrders.Verify(x => x.DeleteAsync(_idOrderValide));
        }
    }
}
