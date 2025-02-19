using EasyGrocery.Domain.Entities;

namespace EasyGrocery.Domain.Repositories
{
    public interface IOrderItemRepository
    {
        Task<bool> CreateOrderItems(List<OrderItem> orderItems);
    }
}
