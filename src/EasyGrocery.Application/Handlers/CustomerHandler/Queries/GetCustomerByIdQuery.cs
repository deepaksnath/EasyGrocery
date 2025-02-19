using EasyGrocery.Domain.Entities;
using MediatR;

namespace EasyGrocery.Application.Handlers.CustomerHandler.Queries
{
    public record GetCustomerByIdQuery(Guid Id) : IRequest<Customer>
    {
    }
}
