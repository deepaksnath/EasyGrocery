using EasyGrocery.Application.Models;
using MediatR;

namespace EasyGrocery.Application.Handlers.CartItemHandler.Commands
{
    public class AddCartItemCommand : IRequest<Guid>
    {
        public AddCartItemCommand(CartItemModel? cartItemModel)
        {
            CartItemModel = cartItemModel;
        }
        public CartItemModel? CartItemModel { get; set; }
    }
}
