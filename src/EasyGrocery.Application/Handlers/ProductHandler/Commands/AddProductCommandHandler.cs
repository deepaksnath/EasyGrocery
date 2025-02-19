using AutoMapper;
using EasyGrocery.Domain.Entities;
using EasyGrocery.Domain.Repositories;
using MediatR;

namespace EasyGrocery.Application.Handlers.ProductHandler.Commands
{
    public class AddProductCommandHandler(IProductRepository productRepository, IMapper mapper) :
                 IRequestHandler<AddProductCommand, Guid>
    {
        public async Task<Guid> Handle(AddProductCommand command, CancellationToken cancellationToken)
        {
            Product product = mapper.Map<Product>(command.productModel);
            var id = await productRepository.AddProducts(product);

            return id;
        }
    }
}
