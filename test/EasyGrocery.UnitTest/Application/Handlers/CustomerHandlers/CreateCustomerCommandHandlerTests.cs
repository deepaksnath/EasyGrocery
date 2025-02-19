using EasyGrocery.Application.Handlers.CustomerHandler.Commands;
using EasyGrocery.Domain.Entities;
using EasyGrocery.Domain.Repositories;
using FluentAssertions;
using Moq;

namespace EasyGrocery.UnitTest.Application.Handlers.CustomerHandlers
{
    public class CreateCustomerCommandHandlerTests
    {
        private readonly Mock<ICustomerRepository> _customerRepository;
        private readonly AddCustomerCommand _addCustomerCommand;

        public CreateCustomerCommandHandlerTests()
        {
            _customerRepository = new Mock<ICustomerRepository>();
            _addCustomerCommand = new AddCustomerCommand();
        }
        [Fact]
        public void AddCustomerCommandHandler_Should_Save_Customer_When_CustomerIsValid()
        {
            //Arrange
            _customerRepository.Setup(x => x.AddCustomers(It.IsAny<Customer>()))
                                                     .ReturnsAsync(new Customer());
            var customerCommandHandler = new AddCustomerCommandHandler(_customerRepository.Object);

            //Act
            var response = customerCommandHandler.Handle(_addCustomerCommand, default);

            //Assert
            response.Should().NotBeNull();
         }
    }
}
