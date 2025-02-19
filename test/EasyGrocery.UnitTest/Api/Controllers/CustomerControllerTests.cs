using EasyGrocery.Api.Controllers;
using EasyGrocery.Api.Models;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace EasyGrocery.UnitTest.Api.Controllers
{
    public class CustomerControllerTests
    {
        private readonly Mock<IMediator> _moqMediator;

        public CustomerControllerTests()
        {
            _moqMediator = new Mock<IMediator>();
        }

        [Fact]
        public async Task Post_Should_Return_BadRequestResponse_When_CustomerModelIsInvalid()
        {
            //Arrange
            var customerController = new CustomerController(_moqMediator.Object);
            _moqMediator.Setup(m => m.Send(It.IsAny<CustomerModel>(), It.IsAny<CancellationToken>()))
                        .ReturnsAsync(true);

            //Act
            var response = await customerController.Post(new CustomerModel());

            //Assert
            response.Should().NotBeNull();
            var result = Assert.IsType<BadRequestObjectResult>(response);
            result.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Get_Should_Return_OkResponse_When_Customers()
        {
            //Arrange
            var customerController = new CustomerController(_moqMediator.Object);
            
            //Act
            var response = await customerController.Get();

            //Assert
            response.Should().NotBeNull();
            var result = Assert.IsType<OkObjectResult>(response);
            result.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
    }
}
