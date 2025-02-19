using EasyGrocery.Domain.Entities;
using EasyGrocery.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EasyGrocery.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly InMemoryDbContext _dbContext;

        public CustomerRepository(InMemoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var list = await _dbContext.Customers.ToListAsync();
            return list;
        }

        public async Task<Customer?> GetCustomerById(Guid id)
        {
            return await _dbContext.Customers.FindAsync(id);
        }

        public async Task<Guid> AddCustomers(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();
            return customer.Id;
        }

        public async Task<bool> UpdateCustomers(Customer customer)
        {
            if (CustomerExists(customer.Id))
            {
                _dbContext.Update(customer);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteCustomer(Guid id)
        {
            var customer = await _dbContext.Customers.FindAsync(id);
            if (customer is not null)
            {
                _dbContext.Customers.Remove(customer);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        private bool CustomerExists(Guid id)
        {
            return _dbContext.Customers.Any(e => e.Id == id);
        }

    }
}
