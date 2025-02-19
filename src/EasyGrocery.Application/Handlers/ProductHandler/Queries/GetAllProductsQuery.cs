using EasyGrocery.Domain.Entities;
using MediatR;

namespace EasyGrocery.Application.Handlers.ProductHandler.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
