using FluentValidation;

namespace EasyGrocery.Application.Handlers.CustomerHandler.Commands
{
    public class AddCustomerCommandHandlerValidator : AbstractValidator<AddCustomerCommand>
    {
        public AddCustomerCommandHandlerValidator()
        {
            RuleFor(Customer => Customer.Name)
                .NotEmpty()
                .WithMessage("Name is required");
            RuleFor(Customer => Customer.Email)
                .NotEmpty()
                .WithMessage("Email is required");
            RuleFor(Customer => Customer.Phone)
                .NotEmpty()
                .WithMessage("Phone is required");
        }
    }
}
