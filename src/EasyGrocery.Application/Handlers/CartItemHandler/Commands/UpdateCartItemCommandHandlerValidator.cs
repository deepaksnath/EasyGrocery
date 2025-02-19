using FluentValidation;

namespace EasyGrocery.Application.Handlers.CartItemHandler.Commands
{
    public class UpdateCartItemCommandHandlerValidator : AbstractValidator<UpdateCartItemCommand>
    {
        public UpdateCartItemCommandHandlerValidator()
        {
            RuleFor(CartItem => CartItem.cartItemModel)
                .NotNull().WithMessage("Cart item info is required");
            RuleFor(CartItem => CartItem.cartItemModel.Id)
                .NotEmpty().WithMessage("Id is required");
            RuleFor(CartItem => CartItem.cartItemModel.ProductId)
                .NotEmpty().WithMessage("Product id is required");
            RuleFor(CartItem => CartItem.cartItemModel.CustomerId)
                .NotEmpty().WithMessage("Customer id is required");
        }
    }
}
