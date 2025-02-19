using EasyGrocery.Domain.Entities;
using EasyGrocery.Domain.Repositories;
using MediatR;

namespace EasyGrocery.Application.Handlers.ProductHandler.Queries
{
    public class GetProductByIdQueryHandler(IProductRepository productRepository) :
        IRequestHandler<GetProductByIdQuery, Product?>
    {
        public async Task<Product?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await productRepository.GetProductById(request.Id);
        }
    }
}
