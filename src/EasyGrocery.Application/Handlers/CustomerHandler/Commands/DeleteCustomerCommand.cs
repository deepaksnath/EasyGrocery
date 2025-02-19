using MediatR;

namespace EasyGrocery.Application.Handlers.CustomerHandler.Commands
{
    public record DeleteCustomerCommand(Guid Id) : IRequest<bool>
    {
    }
}
