using FluentValidation;

namespace EasyGrocery.Application.Handlers.ProductHandler.Commands
{
    public class UpdateProductCommandHandlerValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandHandlerValidator()
        {
            RuleFor(Product => Product.ProductModel)
                .NotNull().WithMessage("Product info is required");
            RuleFor(Product => Product.ProductModel.Id)
                .NotEmpty().WithMessage("Id is required");
            RuleFor(Product => Product.ProductModel.Name)
                .NotEmpty().WithMessage("Name is required");
            RuleFor(Product => Product.ProductModel.Price)
                .NotEmpty().WithMessage("Price is required");
        }
    }
}
