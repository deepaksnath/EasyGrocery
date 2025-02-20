using AutoMapper;
using EasyGrocery.Domain.Entities;
using EasyGrocery.Domain.Repositories;
using MediatR;

namespace EasyGrocery.Application.Handlers.CartItemHandler.Commands
{
    public class UpdateCartItemCommandHandler(ICartItemRepository cartItemRepository, IMapper mapper) :
                 IRequestHandler<UpdateCartItemCommand, bool>
    {
        public async Task<bool> Handle(UpdateCartItemCommand command, CancellationToken cancellationToken)
        {
            CartItem cartItem = mapper.Map<CartItem>(command.CartItemModel);
            bool response = await cartItemRepository.UpdateCartItem(cartItem);

            return response;
        }
    }
}
