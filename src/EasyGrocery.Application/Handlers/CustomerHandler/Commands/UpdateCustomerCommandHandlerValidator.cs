using FluentValidation;

namespace EasyGrocery.Application.Handlers.CustomerHandler.Commands
{
    public class UpdateCustomerCommandHandlerValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandHandlerValidator()
        {
            RuleFor(Customer => Customer.customerModel)
                .NotNull().WithMessage("Customer info is required");
            RuleFor(Customer => Customer.customerModel.Id)
                .NotEmpty().WithMessage("Id is required");
            RuleFor(Customer => Customer.customerModel.Name)
                .NotEmpty().WithMessage("Name is required");
            RuleFor(Customer => Customer.customerModel.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("A valid email is required.");
            RuleFor(Customer => Customer.customerModel.Phone)
                .NotEmpty().WithMessage("Phone is required")
                .MinimumLength(10).WithMessage("Phone must not be less than 10 characters.");
        }
    }
}
