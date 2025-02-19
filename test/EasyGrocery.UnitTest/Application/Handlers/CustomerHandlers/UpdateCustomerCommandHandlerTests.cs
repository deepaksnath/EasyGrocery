using AutoMapper;
using EasyGrocery.Application.Handlers.CustomerHandler.Commands;
using EasyGrocery.Application.Models;
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
        private readonly Mock<IMapper> _mapper;
        public UpdateCustomerCommandHandlerTests()
        {
            _customerRepository = new Mock<ICustomerRepository>();
            _updateCustomerCommand = new UpdateCustomerCommand(new CustomerModel());
            _mapper = new Mock<IMapper>();
        }

        [Fact]
        public void UpdateCustomerCommandHandler_Should_Return_Customer_When_CustomerIsValid()
        {
            //Arrange
            _customerRepository.Setup(x => x.UpdateCustomers(It.IsAny<Customer>()))
                                                     .ReturnsAsync(true);
            var customerCommandHandler = new UpdateCustomerCommandHandler(_customerRepository.Object, _mapper.Object);

            //Act
            var response = customerCommandHandler.Handle(_updateCustomerCommand, default);

            //Assert
            response.Should().NotBeNull();
        }

        [Fact]
        public void UpdateCustomerCommandHandler_Should_Return_Null_When_CustomerDoesNotExist()
        {
            //Arrange
            _customerRepository.Setup(x => x.UpdateCustomers(It.IsAny<Customer>()))
                                                     .ReturnsAsync(false);
            var customerCommandHandler = new UpdateCustomerCommandHandler(_customerRepository.Object, _mapper.Object);

            //Act
            var response = customerCommandHandler.Handle(_updateCustomerCommand, default);

            //Assert
            response!.Result.Should().BeFalse();
        }
    }
}
