using FluentValidation;

namespace EasyGrocery.Application.Handlers.ProductHandler.Commands
{
    public class UpdateProductCommandHandlerValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandHandlerValidator()
        {
            RuleFor(Product => Product.productModel)
                .NotNull().WithMessage("Product info is required");
            RuleFor(Product => Product.productModel.Id)
                .NotEmpty().WithMessage("Id is required");
            RuleFor(Product => Product.productModel.Name)
                .NotEmpty().WithMessage("Name is required");
            RuleFor(Product => Product.productModel.Price)
                .NotEmpty().WithMessage("Price is required");
        }
    }
}
