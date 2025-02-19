using EasyGrocery.Domain.Entities;
using EasyGrocery.Domain.Repositories;

namespace EasyGrocery.Infrastructure.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly EasyDbContext _dbContext;

        public OrderItemRepository(EasyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> CreateOrderItems(List<OrderItem> orderItems)
        {
            await _dbContext.OrderItems.AddRangeAsync(orderItems);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
