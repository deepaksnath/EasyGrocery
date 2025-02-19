using EasyGrocery.Application.Models;
using MediatR;

namespace EasyGrocery.Application.Handlers.ProductHandler.Commands
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public UpdateProductCommand(ProductModel? productModel)
        {
            this.productModel = productModel;
        }
        public ProductModel? productModel { get; set; }
    }
}
