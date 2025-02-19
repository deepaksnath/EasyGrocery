using FluentValidation;

namespace EasyGrocery.Application.Handlers.ProductHandler.Commands
{
    public class AddProductCommandHandlerValidator : AbstractValidator<AddProductCommand>
    {
        public AddProductCommandHandlerValidator()
        {
            RuleFor(Product => Product.productModel)
                .NotNull().WithMessage("Product info is required");
            RuleFor(Product => Product.productModel.Name)
                .NotEmpty().WithMessage("Name is required");
            RuleFor(Product => Product.productModel.Price)
                .NotEmpty().WithMessage("Price is required");
        }
    }
}
