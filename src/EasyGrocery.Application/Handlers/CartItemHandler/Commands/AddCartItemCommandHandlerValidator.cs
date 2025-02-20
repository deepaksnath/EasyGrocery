using FluentValidation;

namespace EasyGrocery.Application.Handlers.CartItemHandler.Commands
{
    public class AddCartItemCommandHandlerValidator : AbstractValidator<AddCartItemCommand>
    {
        public AddCartItemCommandHandlerValidator()
        {
            RuleFor(CartItem => CartItem.CartItemModel)
                .NotNull().WithMessage("Cart item info is required");
            RuleFor(CartItem => CartItem.CartItemModel.ProductId)
                .NotEmpty().WithMessage("Product id is required");
            RuleFor(CartItem => CartItem.CartItemModel.CustomerId)
                .NotEmpty().WithMessage("Customer id is required");
        }
    }
}
