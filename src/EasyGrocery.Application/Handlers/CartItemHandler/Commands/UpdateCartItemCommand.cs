using EasyGrocery.Application.Models;
using MediatR;

namespace EasyGrocery.Application.Handlers.CartItemHandler.Commands
{
    public class UpdateCartItemCommand : IRequest<bool>
    {
        public UpdateCartItemCommand(CartItemModel? cartItemModel)
        {
            CartItemModel = cartItemModel;
        }
        public CartItemModel? CartItemModel { get; set; }
    }
}
