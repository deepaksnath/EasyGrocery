using EasyGrocery.Domain.Repositories;
using MediatR;

namespace EasyGrocery.Application.Handlers.ProductHandler.Commands
{
    public class DeleteProductCommandHandler(IProductRepository productRepository) :
        IRequestHandler<DeleteProductCommand, bool>
    {
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await productRepository.DeleteProduct(request.Id);
        }
    }
}
