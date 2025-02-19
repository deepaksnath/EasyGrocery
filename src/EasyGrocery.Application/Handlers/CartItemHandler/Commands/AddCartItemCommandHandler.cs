using AutoMapper;
using EasyGrocery.Domain.Entities;
using EasyGrocery.Domain.Repositories;
using MediatR;

namespace EasyGrocery.Application.Handlers.CartItemHandler.Commands
{
    public class AddCartItemCommandHandler(ICartItemRepository cartItemRepository, IMapper mapper) :
                 IRequestHandler<AddCartItemCommand, Guid>
    {
        public async Task<Guid> Handle(AddCartItemCommand command, CancellationToken cancellationToken)
        {
            CartItem cartItem = mapper.Map<CartItem>(command.cartItemModel);
            var id = await cartItemRepository.AddCartItem(cartItem);

            return id;
        }
    }
}
