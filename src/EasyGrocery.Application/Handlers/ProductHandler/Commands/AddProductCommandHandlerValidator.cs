using FluentValidation;

namespace EasyGrocery.Application.Handlers.ProductHandler.Commands
{
    public class AddProductCommandHandlerValidator : AbstractValidator<AddProductCommand>
    {
        public AddProductCommandHandlerValidator()
        {
            RuleFor(Product => Product.ProductModel)
                .NotNull().WithMessage("Product info is required");
            RuleFor(Product => Product.ProductModel.Name)
                .NotEmpty().WithMessage("Name is required");
            RuleFor(Product => Product.ProductModel.Price)
                .NotEmpty().WithMessage("Price is required");
        }
    }
}
