using EasyGrocery.Domain.Entities;

namespace EasyGrocery.Domain.Repositories
{
    public interface ICartItemRepository
    {
        Task<Guid> AddCartItem(CartItem cartItem);
        Task<bool> UpdateCartItem(CartItem cartItem);
        Task<IList<CartItem>> GetCartItemsByCustomerAsync(Guid customerId);
        Task<bool> RemoveCartItemsByCustomerAsync(Guid customerId);
    }
}
