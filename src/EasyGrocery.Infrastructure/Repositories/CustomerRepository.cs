using EasyGrocery.Domain.Entities;
using EasyGrocery.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EasyGrocery.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SqlDbContext _sqlDbContext;

        public CustomerRepository(SqlDbContext sqlDbContext)
        {
            _sqlDbContext = sqlDbContext;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var list = await _sqlDbContext.Customers.ToListAsync();
            return list;
        }

        public async Task<Customer?> GetCustomerById(Guid id)
        {
            return await _sqlDbContext.Customers.FindAsync(id);
        }

        public async Task<Customer> AddCustomers(Customer customer)
        {
            _sqlDbContext.Customers.Add(customer);
            await _sqlDbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer?> UpdateCustomers(Customer customer)
        {
            if (CustomerExists(customer.Id))
            {
                _sqlDbContext.Update(customer);
                await _sqlDbContext.SaveChangesAsync();
                return customer;
            }
            return null;
        }

        public async Task<Customer?> DeleteCustomer(Guid id)
        {
            var customer = await _sqlDbContext.Customers.FindAsync(id);
            if (customer is not null)
            {
                _sqlDbContext.Customers.Remove(customer);
                await _sqlDbContext.SaveChangesAsync();
                return customer;
            }
            return null;
        }

        private bool CustomerExists(Guid id)
        {
            return _sqlDbContext.Customers.Any(e => e.Id == id);
        }

    }
}
