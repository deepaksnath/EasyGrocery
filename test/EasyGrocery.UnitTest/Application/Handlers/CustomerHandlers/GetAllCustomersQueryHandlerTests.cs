using EasyGrocery.Application.Handlers.CustomerHandler.Queries;
using EasyGrocery.Domain.Entities;
using EasyGrocery.Domain.Repositories;
using FluentAssertions;
using Moq;

namespace EasyGrocery.UnitTest.Application.Handlers.CustomerHandlers
{
    public class GetAllCustomersQueryHandlerTests
    {
        private readonly Mock<ICustomerRepository> _customerRepository;
        private readonly GetAllCustomersQuery _getAllCustomersQuery;

        public GetAllCustomersQueryHandlerTests()
        {
            _customerRepository = new Mock<ICustomerRepository>();
            _getAllCustomersQuery = new GetAllCustomersQuery();
        }

        [Fact]
        public void GetAllCustomersQueryHandler_Should_Return_EmptyList_When_CustomerDoesNotExist()
        {
            //Arrange
            _customerRepository.Setup(x => x.GetCustomers())
                               .ReturnsAsync(new List<Customer>());

            //Act
            var getAllCustomersQueryHandler = new GetAllCustomersQueryHandler(_customerRepository.Object);
            var response = getAllCustomersQueryHandler!.Handle(_getAllCustomersQuery, default);

            //Assert
            response!.Result.Should().NotBeNull();
            response!.Result.Should().BeEmpty();
        }
    }
}
