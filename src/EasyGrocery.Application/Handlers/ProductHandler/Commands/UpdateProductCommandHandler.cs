using AutoMapper;
using EasyGrocery.Domain.Entities;
using EasyGrocery.Domain.Repositories;
using MediatR;

namespace EasyGrocery.Application.Handlers.ProductHandler.Commands
{
    public class UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper) :
                 IRequestHandler<UpdateProductCommand, bool>
    {
        public async Task<bool> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            Product product = mapper.Map<Product>(command.productModel);
            bool response = await productRepository.UpdateProduct(product);

            return response;
        }
    }
}
