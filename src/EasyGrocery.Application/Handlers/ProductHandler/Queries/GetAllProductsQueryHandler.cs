using EasyGrocery.Domain.Entities;
using EasyGrocery.Domain.Repositories;
using MediatR;

namespace EasyGrocery.Application.Handlers.ProductHandler.Queries
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProducts();

            return products;
        }
    }
}
