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
    public class CustomersControllerTests
    {

        private readonly Mock<ICustomers> _mockCustomer = new Mock<ICustomers>();

        private readonly int _idCustomerValide = 1;

        private readonly int _idCustomerNotValide = 7;

        private readonly List<Customer> _customersListTest = new List<Customer>()
        {
            new Customer () { Id = 1 },
        };

        private readonly Customer _newCustomerrTest = new Customer();

        private readonly Customer _validCustomerTest = new Customer();
       

        [Fact]
        public async Task Details_Return_Customer()
        {
            //Arrange            
            _mockCustomer.Setup(x => x.GetByIdAsync(_idCustomerValide)).ReturnsAsync(_customersListTest.FirstOrDefault(x => x.Id == _idCustomerValide));
            var customersController = new CustomersController(_mockCustomer.Object);

            //Act
            var action = await customersController.Details(_idCustomerValide);

            //Assert
            var actionView = Assert.IsType<ViewResult>(action);
            var actionModel = Assert.IsType<Customer>(actionView.Model);
            Assert.Equal(_idCustomerValide, actionModel.Id);
            Assert.Equal(_customersListTest.Find(x => x.Id == actionModel.Id).LastName, actionModel.LastName);
            Assert.Equal(_customersListTest.Find(x => x.Id == actionModel.Id).FirstName, actionModel.FirstName);
            Assert.Equal(_customersListTest.Find(x => x.Id == actionModel.Id).Address, actionModel.Address);
            Assert.Equal(_customersListTest.Find(x => x.Id == actionModel.Id).Discount, actionModel.Discount);
        }

        [Fact]
        public async Task Details_Return_BadRequest()
        {
            //Arrange            
            _mockCustomer.Setup(x => x.GetByIdAsync(_idCustomerNotValide)).Throws(new Exception());
            var customersController = new CustomersController(_mockCustomer.Object);

            //Act
            var action = await customersController.Details(_idCustomerNotValide);

            //Assert
            var actionBadRequest = Assert.IsType<BadRequestResult>(action);
            Assert.Equal(400, actionBadRequest.StatusCode);
        }

        [Fact]
        public void Create_Get()
        {
            var customersController = new CustomersController(_mockCustomer.Object);

            var action = customersController.Create();

            Assert.IsType<ViewResult>(action);
        }        

        [Fact]
        public async Task Edit_Get_Return_Customer()
        {
            //Arrange            
            _mockCustomer.Setup(x => x.GetByIdAsync(_idCustomerValide)).ReturnsAsync(_customersListTest.FirstOrDefault(x => x.Id == _idCustomerValide));
            var customersController = new CustomersController(_mockCustomer.Object);

            //Act
            var action = await customersController.Edit(_idCustomerValide);

            //Assert
            var actionView = Assert.IsType<ViewResult>(action);
            var actionModel = Assert.IsType<Customer>(actionView.Model);
            Assert.Equal(_idCustomerValide, actionModel.Id);
            Assert.Equal(_customersListTest.Find(x => x.Id == actionModel.Id).LastName, actionModel.LastName);
            Assert.Equal(_customersListTest.Find(x => x.Id == actionModel.Id).FirstName, actionModel.FirstName);
            Assert.Equal(_customersListTest.Find(x => x.Id == actionModel.Id).Address, actionModel.Address);
            Assert.Equal(_customersListTest.Find(x => x.Id == actionModel.Id).Discount, actionModel.Discount);
        }

        [Fact]
        public async Task Edit_Get_Return_NotFoundResult()
        {
            //Arrange            
            _mockCustomer.Setup(x => x.GetByIdAsync(_idCustomerNotValide)).ReturnsAsync(_customersListTest.FirstOrDefault(x => x.Id != _idCustomerValide));
            var customersController = new CustomersController(_mockCustomer.Object);

            //Act
            var action = await customersController.Edit(_idCustomerNotValide);

            //Assert
            var actionNotFound = Assert.IsType<NotFoundResult>(action);
            Assert.Equal(404, actionNotFound.StatusCode);
        }        

        [Fact]
        public async Task Edit_Post_Return_NotFound()
        {
            //Arrange            
            _mockCustomer.Setup(x => x.GetByIdAsync(_idCustomerValide)).ReturnsAsync(_customersListTest.FirstOrDefault(x => x.Id != _idCustomerValide));
            var customersController = new CustomersController(_mockCustomer.Object);

            //Act
            var action = await customersController.Edit(_idCustomerNotValide);

            //Assert
            var actionNotFound = Assert.IsType<NotFoundResult>(action);
            Assert.Equal(404, actionNotFound.StatusCode);
        }       

        [Fact]
        public async Task Delete_Post()
        {
            //Arrange     
            _mockCustomer.Setup(x => x.DeleteAsync(_idCustomerValide));
            _mockCustomer.Setup(x => x.DeleteAsync(_idCustomerNotValide)).Throws(new Exception());
            var customersController = new CustomersController(_mockCustomer.Object);

            //Act
            var actionValide = await customersController.DeleteConfirmed(_idCustomerValide);
            var actionNotValide = await customersController.DeleteConfirmed(_idCustomerNotValide);

            //Assert
            Assert.IsType<ViewResult>(actionNotValide);
            Assert.IsType<RedirectToActionResult>(actionValide);
            _mockCustomer.Verify(x => x.DeleteAsync(_idCustomerValide));
        }
    }
}
