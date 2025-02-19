using MediatR;

namespace EasyGrocery.Application.Handlers.ProductHandler.Commands
{
    public record DeleteProductCommand(Guid Id) : IRequest<bool>
    {
    }
}
