using EasyGrocery.Domain.Entities;
using EasyGrocery.Domain.Repositories;
using MediatR;

namespace EasyGrocery.Application.Handlers.CartItemHandler.Queries
{
    public class GetCartItemsByCustomerIdQueryHandler(ICartItemRepository cartItemRepository) : 
                 IRequestHandler<GetCartItemsByCustomerIdQuery, IEnumerable<CartItem>>
    {       
        public async Task<IEnumerable<CartItem>> Handle(GetCartItemsByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            return await cartItemRepository.GetCartItemsByCustomerAsync(request.Id);
        }
    }
}
