using FluentValidation;

namespace EasyGrocery.Application.Handlers.CartItemHandler.Commands
{
    public class UpdateCartItemCommandHandlerValidator : AbstractValidator<UpdateCartItemCommand>
    {
        public UpdateCartItemCommandHandlerValidator()
        {
            RuleFor(CartItem => CartItem.CartItemModel)
                .NotNull().WithMessage("Cart item info is required");
            RuleFor(CartItem => CartItem.CartItemModel.Id)
                .NotEmpty().WithMessage("Id is required");
            RuleFor(CartItem => CartItem.CartItemModel.ProductId)
                .NotEmpty().WithMessage("Product id is required");
            RuleFor(CartItem => CartItem.CartItemModel.CustomerId)
                .NotEmpty().WithMessage("Customer id is required");
        }
    }
}
