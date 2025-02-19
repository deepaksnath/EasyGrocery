using EasyGrocery.Domain.Entities;

namespace EasyGrocery.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer?> GetCustomerById(Guid id);
        Task<Customer> AddCustomers(Customer customer);
        Task<Customer?> UpdateCustomers(Customer customer);
        Task<Customer?> DeleteCustomer(Guid id);
    }
}
