using EasyGrocery.Application.Models;
using MediatR;

namespace EasyGrocery.Application.Handlers.CustomerHandler.Commands
{
    public class UpdateCustomerCommand : IRequest<bool>
    {
        public UpdateCustomerCommand(CustomerModel? customerModel)
        {
            CustomerModel = customerModel;
        }
        public CustomerModel? CustomerModel { get; set; }
    }
}
