using EasyGrocery.Domain.Entities;
using EasyGrocery.Infrastructure.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace EasyGrocery.UnitTest.Infrastructure.Repositories
{
    public class CustomerRepositoryTests
    {
        private readonly EasyDbContext dbContext;
        public CustomerRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<EasyDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            dbContext = new EasyDbContext(options);
        }


        [Fact]
        public async Task AddCustomers_Should_Return_Guid_When_Customer_IsValid()
        {
            //Arrange
            var customerRepository = new CustomerRepository(dbContext);
            
            //Act
            var response = await customerRepository.AddCustomers(new Customer { Name = "Deepak" });

            //Assert
            response.Should().NotBe(Guid.Empty);
        }

        [Fact]
        public async Task UpdateCustomers_Should_Return_false_When_Customer_IsNotValid()
        {
            //Arrange
            var customerRepository = new CustomerRepository(dbContext);

            //Act
            var response = await customerRepository.UpdateCustomers(new Customer { Name = "Deepak" });

            //Assert
            response.Should().Be(false);
        }

        [Fact]
        public async Task GetAllCustomers_Should_ReturnCustomerList_When_CustomersExists()
        {
            //Arrange
            var customerRepository = new CustomerRepository(dbContext);

            //Act
            var response = await customerRepository.GetCustomers();

            //Assert
            response.Should().NotBeNull();
        }
    }
}
