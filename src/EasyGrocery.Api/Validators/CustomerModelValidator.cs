using EasyGrocery.Api.Models;
using FluentValidation;

namespace EasyGrocery.Api.Validators
{
    public class CustomerModelValidator : AbstractValidator<CustomerModel>
    {
        public CustomerModelValidator()
        {
            RuleFor(Customer=>Customer.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(Customer => Customer.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(Customer => Customer.Phone).NotEmpty().WithMessage("Phone is required");
        }
    }
}
