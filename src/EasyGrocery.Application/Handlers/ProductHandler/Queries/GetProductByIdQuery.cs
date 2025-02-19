using EasyGrocery.Domain.Entities;
using MediatR;

namespace EasyGrocery.Application.Handlers.ProductHandler.Queries
{
    public record GetProductByIdQuery(Guid Id) : IRequest<Product>
    {
    }
}
