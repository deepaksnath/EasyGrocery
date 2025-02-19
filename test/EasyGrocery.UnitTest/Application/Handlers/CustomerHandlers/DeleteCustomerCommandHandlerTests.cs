using EasyGrocery.Application.Handlers.CustomerHandler.Commands;
using EasyGrocery.Domain.Entities;
using EasyGrocery.Domain.Repositories;
using FluentAssertions;
using Moq;

namespace EasyGrocery.UnitTest.Application.Handlers.CustomerHandlers
{
    public class DeleteCustomerCommandHandlerTests
    {
        private readonly Mock<ICustomerRepository> _customerRepository;
        private readonly DeleteCustomerCommand _deleteCustomerCommand;

        public DeleteCustomerCommandHandlerTests()
        {
            _customerRepository = new Mock<ICustomerRepository>();
            _deleteCustomerCommand = new DeleteCustomerCommand(Guid.Empty);
        }
        [Fact]
        public void DeleteCustomerCommandHandler_Should_Return_Customer_When_CustomerIsValid()
        {
            //Arrange
            _customerRepository.Setup(x => x.DeleteCustomer(It.IsAny<Guid>()))
                                                     .ReturnsAsync(true);
            var customerCommandHandler = new DeleteCustomerCommandHandler(_customerRepository.Object);

            //Act
            var response = customerCommandHandler.Handle(_deleteCustomerCommand, default);

            //Assert
            response.Should().NotBeNull();
        }

        [Fact]
        public void DeleteCustomerCommandHandler_Should_Return_Null_When_CustomerDoesNotExist()
        {
            //Arrange
            _customerRepository.Setup(x => x.DeleteCustomer(It.IsAny<Guid>()))
                                                     .ReturnsAsync(false);
            var customerCommandHandler = new DeleteCustomerCommandHandler(_customerRepository.Object);

            //Act
            var response = customerCommandHandler.Handle(_deleteCustomerCommand, default);

            //Assert
            response!.Result.Should().BeFalse();
        }
    }
}
