using EasyGrocery.Domain.Entities;
using EasyGrocery.Domain.Repositories;

namespace EasyGrocery.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EasyDbContext _dbContext;

        public OrderRepository(EasyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> CreateOrder(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return order.Id;
        }
    }
}
