using EasyGrocery.Domain.Entities;
using MediatR;

namespace EasyGrocery.Application.Handlers.CartItemHandler.Queries
{
    public record GetCartItemsByCustomerIdQuery(Guid Id) : IRequest<IEnumerable<CartItem>>
    {
    }
}
