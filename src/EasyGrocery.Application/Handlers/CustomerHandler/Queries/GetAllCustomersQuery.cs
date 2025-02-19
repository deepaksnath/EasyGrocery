using EasyGrocery.Domain.Entities;
using MediatR;

namespace EasyGrocery.Application.Handlers.CustomerHandler.Queries
{
    public class GetAllCustomersQuery : IRequest<IEnumerable<Customer>>
    {
    }
}
