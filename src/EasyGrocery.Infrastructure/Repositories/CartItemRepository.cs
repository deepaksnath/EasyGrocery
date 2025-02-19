using EasyGrocery.Domain.Entities;
using EasyGrocery.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EasyGrocery.Infrastructure.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly EasyDbContext _dbContext;

        public CartItemRepository(EasyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> AddCartItem(CartItem cartItem)
        {
            _dbContext.CartItems.Add(cartItem);
            await _dbContext.SaveChangesAsync();
            return cartItem.Id;
        }
        public async Task<IList<CartItem>> GetCartItemsByCustomerAsync(Guid customerId)
        {
            return await _dbContext.CartItems.Where(c => c.CustomerId == customerId).ToListAsync();
        }
        public async Task<bool> RemoveCartItemsByCustomerAsync(Guid customerId)
        {
            var items = _dbContext.CartItems.Where(x => x.CustomerId == customerId);
            _dbContext.CartItems.RemoveRange(items);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateCartItem(CartItem cartItem)
        {
            if (CartItemExists(cartItem.Id))
            {
                _dbContext.Update(cartItem);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        private bool CartItemExists(Guid id)
        {
            return _dbContext.CartItems.Any(e => e.Id == id);
        }
    }
}
