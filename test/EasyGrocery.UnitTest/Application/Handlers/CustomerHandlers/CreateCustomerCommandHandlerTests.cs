using AutoMapper;
using EasyGrocery.Application.Handlers.CustomerHandler.Commands;
using EasyGrocery.Application.Models;
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
        private readonly Mock<IMapper> _mapper;

        public CreateCustomerCommandHandlerTests()
        {
            _customerRepository = new Mock<ICustomerRepository>();
            _addCustomerCommand = new AddCustomerCommand(new CustomerModel());
            _mapper = new Mock<IMapper>();
        }
        [Fact]
        public void AddCustomerCommandHandler_Should_Save_Customer_When_CustomerIsValid()
        {
            //Arrange
            _customerRepository.Setup(x => x.AddCustomers(It.IsAny<Customer>()))
                                                     .ReturnsAsync(Guid.NewGuid);
            var customerCommandHandler = new AddCustomerCommandHandler(_customerRepository.Object, _mapper.Object);

            //Act
            var response = customerCommandHandler.Handle(_addCustomerCommand, default);

            //Assert
            response.Should().NotBeNull();
         }
    }
}
