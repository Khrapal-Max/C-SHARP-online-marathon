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
    public class SupermarketsControllerTests
    {
        private readonly Mock<ISupermarkets> _mockSupermarkets = new Mock<ISupermarkets>();

        private readonly int _idSupermarketValide = 1;

        private readonly int _idSupermarketNotValide = 7;

        private readonly List<Supermarket> _supermarketsListTest = new List<Supermarket>()
        {
            new Supermarket { Id = 1, Name = "Shop1", Address = "Address1" },
            new Supermarket { Id = 2, Name = "Shop2", Address = "Address2" },
            new Supermarket { Id = 3, Name = "Shop3", Address = "Address3" }
        };

        private readonly Supermarket _newSupermarketValidTest = new Supermarket() { Name = "Shop4", Address = "Address4" };

        private readonly Supermarket _supermarketValidTest = new Supermarket() { Id = 1, Name = "Shop1", Address = "Address1" };

        [Fact]
        public async Task Index_Return_List_Supermarkets()
        {
            //Arrange
            _mockSupermarkets.Setup(x => x.GetAllAsync()).ReturnsAsync(_supermarketsListTest).Verifiable();
            var supermarketsController = new SupermarketsController(_mockSupermarkets.Object);

            //Act
            var action = await supermarketsController.Index();

            //Assert
            var actionModel = Assert.IsType<ViewResult>(action);
            Assert.Equal(_supermarketsListTest, actionModel.Model);
        }

        [Fact]
        public async Task Details_Return_Supermarket()
        {
            //Arrange            
            _mockSupermarkets.Setup(x => x.GetByIdAsync(_idSupermarketValide)).ReturnsAsync(_supermarketsListTest.FirstOrDefault(x => x.Id == _idSupermarketValide));
            var supermarketsController = new SupermarketsController(_mockSupermarkets.Object);

            //Act
            var action = await supermarketsController.Details(_idSupermarketValide);

            //Assert
            var actionView = Assert.IsType<ViewResult>(action);
            var actionModel = Assert.IsType<Supermarket>(actionView.Model);
            Assert.Equal(_idSupermarketValide, actionModel.Id);
            Assert.Equal(_supermarketsListTest.Find(x => x.Id == actionModel.Id).Name, actionModel.Name);
            Assert.Equal(_supermarketsListTest.Find(x => x.Id == actionModel.Id).Address, actionModel.Address);
        }

        [Fact]
        public async Task Details_Return_BadRequest()
        {
            //Arrange            
            _mockSupermarkets.Setup(x => x.GetByIdAsync(_idSupermarketNotValide)).Throws(new Exception());
            var supermarketsController = new SupermarketsController(_mockSupermarkets.Object);

            //Act
            var action = await supermarketsController.Details(_idSupermarketNotValide);

            //Assert
            var actionBadRequest = Assert.IsType<BadRequestResult>(action);
            Assert.Equal(400, actionBadRequest.StatusCode);
        }

        [Fact]
        public void Create_Get()
        {
            var supermarketsController = new SupermarketsController(_mockSupermarkets.Object);

            var action = supermarketsController.Create();

            Assert.IsType<ViewResult>(action);
        }

        [Fact]
        public async Task Create_Post_New_and_Add_Supermarket()
        {
            //Arrange      
            var supermarketsController = new SupermarketsController(_mockSupermarkets.Object);
            supermarketsController.ModelState.GetValidationState("Valid model");

            //Act
            var actionValide = await supermarketsController.Create(_newSupermarketValidTest);            

            //Assert   
            var actionRedirect = Assert.IsType<RedirectToActionResult>(actionValide);
            Assert.Equal("Index", actionRedirect.ActionName);
            _mockSupermarkets.Verify();           
        }

        [Fact]
        public async Task Create_Post_BadRequest()
        {
            //Arrange      
            var supermarketsController = new SupermarketsController(_mockSupermarkets.Object);           
            supermarketsController.ModelState.AddModelError("Error", "Not valide model");

            //Act            
            var actionNull = await supermarketsController.Create(null);

            //Assert 
            Assert.IsType<ViewResult>(actionNull);
        }

        [Fact]
        public async Task Edit_Get_Return_Supermarket()
        {
            //Arrange            
            _mockSupermarkets.Setup(x => x.GetByIdAsync(_idSupermarketValide)).ReturnsAsync(_supermarketsListTest.FirstOrDefault(x => x.Id == _idSupermarketValide));
            var supermarketsController = new SupermarketsController(_mockSupermarkets.Object);

            //Act
            var action = await supermarketsController.Edit(_idSupermarketValide);

            //Assert
            var actionView = Assert.IsType<ViewResult>(action);
            var actionModel = Assert.IsType<Supermarket>(actionView.Model);
            Assert.Equal(_idSupermarketValide, actionModel.Id);
            Assert.Equal(_supermarketsListTest.Find(x => x.Id == actionModel.Id).Name, actionModel.Name);
            Assert.Equal(_supermarketsListTest.Find(x => x.Id == actionModel.Id).Address, actionModel.Address);
        }

        [Fact]
        public async Task Edit_Get_Return_BadRequest()
        {
            //Arrange            
            _mockSupermarkets.Setup(x => x.GetByIdAsync(_idSupermarketValide)).Throws(new Exception());
            var supermarketsController = new SupermarketsController(_mockSupermarkets.Object);

            //Act
            var action = await supermarketsController.Edit(_idSupermarketValide);

            //Assert
            var actionBadRequest = Assert.IsType<BadRequestResult>(action);
            Assert.Equal(400, actionBadRequest.StatusCode);
        }

        [Fact]
        public async Task Edit_Post_Supermarket()
        {
            //Arrange   
            _mockSupermarkets.Setup(x => x.EditAsync(_supermarketValidTest));
            var supermarketsController = new SupermarketsController(_mockSupermarkets.Object);

            //Act
            var action = await supermarketsController.Edit(_idSupermarketValide, _supermarketValidTest);

            //Assert         
            Assert.IsType<RedirectToActionResult>(action);
            _mockSupermarkets.Verify(x => x.EditAsync(_supermarketValidTest));
        }

        [Fact]
        public async Task Edit_Post_Return_BadRequest()
        {
            //Arrange            
            _mockSupermarkets.Setup(x => x.EditAsync(_newSupermarketValidTest)).Throws(new Exception());
            var supermarketsController = new SupermarketsController(_mockSupermarkets.Object);

            //Act
            var action = await supermarketsController.Edit(_newSupermarketValidTest.Id, _newSupermarketValidTest);

            //Assert
            var actionBadRequest = Assert.IsType<BadRequestResult>(action);
            Assert.Equal(400, actionBadRequest.StatusCode);
        }

        [Fact]
        public async Task Delete_Get()
        {
            //Arrange 
            _mockSupermarkets.Setup(x => x.DeleteAsync(_idSupermarketValide)).Verifiable();
            _mockSupermarkets.Setup(x => x.DeleteAsync(_idSupermarketNotValide)).Throws(new Exception());
            var supermarketsController = new SupermarketsController(_mockSupermarkets.Object);

            //Act            
            var actionValide = await supermarketsController.Delete(_idSupermarketValide);
            var actionNotValide = await supermarketsController.Delete(_idSupermarketNotValide);

            //Assert
            Assert.IsType<ViewResult>(actionNotValide);
            Assert.IsType<RedirectToActionResult>(actionValide);
            _mockSupermarkets.Verify(x => x.DeleteAsync(_idSupermarketValide));
        }

        [Fact]
        public async Task Delete_Post()
        {
            //Arrange     
            _mockSupermarkets.Setup(x => x.DeleteAsync(_idSupermarketValide));
            var supermarketsController = new SupermarketsController(_mockSupermarkets.Object);

            //Act
            var actionValide = await supermarketsController.DeleteConfirmed(_idSupermarketValide);

            //Assert
            var actionRedirect = Assert.IsType<RedirectToActionResult>(actionValide);
            Assert.Equal("Index", actionRedirect.ActionName);
            _mockSupermarkets.Verify(x => x.DeleteAsync(_idSupermarketValide));
        }
    }
}
