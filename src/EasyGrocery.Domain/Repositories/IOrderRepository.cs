using EasyGrocery.Domain.Entities;

namespace EasyGrocery.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<Guid> CreateOrder(Order order);
    }
}
