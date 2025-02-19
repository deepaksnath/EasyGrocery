using EasyGrocery.Application.Handlers.CustomerHandler.Queries;
using EasyGrocery.Domain.Entities;
using EasyGrocery.Domain.Repositories;
using FluentAssertions;
using Moq;

namespace EasyGrocery.UnitTest.Application.Handlers.CustomerHandlers
{
    public class GetCustomerByIdQueryHandlerTests
    {
        private readonly Mock<ICustomerRepository> _customerRepository;
        private readonly GetCustomerByIdQuery _getCustomerByIdQuery;

        public GetCustomerByIdQueryHandlerTests()
        {
            _customerRepository = new Mock<ICustomerRepository>();
            _getCustomerByIdQuery = new GetCustomerByIdQuery(Guid.Empty);
        }

        [Fact]
        public void GetCustomerByIdQueryHandler_Should_Return_Null_When_CustomerDoesNotExist()
        {
            //Arrange
            Customer? ret = null;
            _customerRepository.Setup(x => x.GetCustomerById(It.IsAny<Guid>()))
                               .ReturnsAsync(ret);

            //Act
            var getCustomerByIdQueryHandler = new GetCustomerByIdQueryHandler(_customerRepository.Object);
            var response = getCustomerByIdQueryHandler!.Handle(_getCustomerByIdQuery, default);

            //Assert
            response!.Result.Should().BeNull();
        }
    }
}
