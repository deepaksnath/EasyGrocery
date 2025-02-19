using EasyGrocery.Api.Controllers;
using EasyGrocery.Application.Models;
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
        public async Task Post_Should_Return_CreatedResponse_When_CustomerModelIsValid()
        {
            //Arrange
            var customerController = new CustomerController(_moqMediator.Object);
            _moqMediator.Setup(m => m.Send(It.IsAny<CustomerModel>(), It.IsAny<CancellationToken>()))
                        .ReturnsAsync(true);

            //Act
            var response = await customerController.Post(new CustomerModel());

            //Assert
            response.Should().NotBeNull();
            var result = Assert.IsType<ObjectResult>(response);
            result.StatusCode.Should().Be((int)HttpStatusCode.Created);
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

        [Fact]
        public async Task Put_Should_Return_NotFoundResponse_When_CustomerDoesNotExist()
        {
            //Arrange
            var customerController = new CustomerController(_moqMediator.Object);
            _moqMediator.Setup(m => m.Send(It.IsAny<CustomerModel>(), It.IsAny<CancellationToken>()))
                        .ReturnsAsync(false);

            //Act
            var response = await customerController.Put(Guid.NewGuid(), new CustomerModel());

            //Assert
            response.Should().NotBeNull();
            var result = Assert.IsType<NotFoundResult>(response);
            result.StatusCode.Should().Be((int)HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Delete_Should_Return_NotFoundResponse_When_CustomerDoesNotExist()
        {
            //Arrange
            var customerController = new CustomerController(_moqMediator.Object);
            _moqMediator.Setup(m => m.Send(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                        .ReturnsAsync(false);

            //Act
            var response = await customerController.Delete(Guid.NewGuid());

            //Assert
            response.Should().NotBeNull();
            var result = Assert.IsType<NotFoundResult>(response);
            result.StatusCode.Should().Be((int)HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetById_Should_Return_OkResponse_When_Customers()
        {
            //Arrange
            var customerController = new CustomerController(_moqMediator.Object);
            _moqMediator.Setup(m => m.Send(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                        .ReturnsAsync(false);

            //Act
            var response = await customerController.Get(Guid.NewGuid());

            //Assert
            response.Should().NotBeNull();
            var result = Assert.IsType<NotFoundResult>(response);
            result.StatusCode.Should().Be((int)HttpStatusCode.NotFound);
        }

    }
}
