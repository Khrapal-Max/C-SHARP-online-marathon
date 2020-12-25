using Moq;
using NUnit.Framework;
using ShoppingSystem.Data;
using ShoppingSystem.Models;
using ShoppingSystem.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NUnitShoppingSystem.Test.ServicesTests
{
    [TestFixture]
    class CustomersServiceTest
    {
        [Test]
        public async Task AddAsync()
        {
            //Arrange     
            var sut = new Customer()
            {
                Id = 1,
                LastName = "LN",
                FirstName = "FN",
                Address = "Address",
                Discount = "A"
            };

            var customerMock = new Mock<CustomersService>();

            //Act

            customerMock.Setup(x => x.AddAsync(sut)).Verifiable();
            

            //Assert
           
        }
    }
}
