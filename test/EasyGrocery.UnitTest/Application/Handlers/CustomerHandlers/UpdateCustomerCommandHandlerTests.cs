using EasyGrocery.Application.Handlers.CustomerHandler.Commands;
using EasyGrocery.Domain.Entities;
using EasyGrocery.Domain.Repositories;
using FluentAssertions;
using Moq;

namespace EasyGrocery.UnitTest.Application.Handlers.CustomerHandlers
{
    public class UpdateCustomerCommandHandlerTests
    {
        private readonly Mock<ICustomerRepository> _customerRepository;
        private readonly UpdateCustomerCommand _updateCustomerCommand;

        public UpdateCustomerCommandHandlerTests()
        {
            _customerRepository = new Mock<ICustomerRepository>();
            _updateCustomerCommand = new UpdateCustomerCommand();
        }

        [Fact]
        public void UpdateCustomerCommandHandler_Should_Return_Customer_When_CustomerIsValid()
        {
            //Arrange
            _customerRepository.Setup(x => x.UpdateCustomers(It.IsAny<Customer>()))
                                                     .ReturnsAsync(new Customer());
            var customerCommandHandler = new UpdateCustomerCommandHandler(_customerRepository.Object);

            //Act
            var response = customerCommandHandler.Handle(_updateCustomerCommand, default);

            //Assert
            response.Should().NotBeNull();
        }

        [Fact]
        public void UpdateCustomerCommandHandler_Should_Return_Null_When_CustomerDoesNotExist()
        {
            //Arrange
            Customer? customer = null;
            _customerRepository.Setup(x => x.UpdateCustomers(It.IsAny<Customer>()))
                                                     .ReturnsAsync(customer);
            var customerCommandHandler = new UpdateCustomerCommandHandler(_customerRepository.Object);

            //Act
            var response = customerCommandHandler.Handle(_updateCustomerCommand, default);

            //Assert
            response!.Result.Should().BeNull();
        }
    }
}
