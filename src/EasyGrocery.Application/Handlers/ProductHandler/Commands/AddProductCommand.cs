using EasyGrocery.Application.Models;
using MediatR;

namespace EasyGrocery.Application.Handlers.ProductHandler.Commands
{
    public class AddProductCommand : IRequest<Guid>
    {
        public AddProductCommand(ProductModel? productModel)
        {
            this.productModel = productModel;
        }
        public ProductModel? productModel { get; set; }
    }
}
