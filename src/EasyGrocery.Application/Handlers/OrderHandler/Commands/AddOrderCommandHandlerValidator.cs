using FluentValidation;

namespace EasyGrocery.Application.Handlers.OrderHandler.Commands
{
    public class AddOrderCommandHandlerValidator : AbstractValidator<AddOrderCommand>
    {
        public AddOrderCommandHandlerValidator()
        {
            RuleFor(Order => Order.orderModel)
                .NotNull().WithMessage("Order info is required");
            RuleFor(Order => Order.orderModel.CustomerId)
                .NotEmpty().WithMessage("CustomerId is required");
        }
    }
}
