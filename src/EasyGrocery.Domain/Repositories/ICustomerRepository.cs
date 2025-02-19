using EasyGrocery.Domain.Entities;

namespace EasyGrocery.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer?> GetCustomerById(Guid id);
        Task<Guid> AddCustomers(Customer customer);
        Task<bool> UpdateCustomers(Customer customer);
        Task<bool> DeleteCustomer(Guid id);
    }
}
