using EasyGrocery.Application.Models;
using MediatR;

namespace EasyGrocery.Application.Handlers.CustomerHandler.Commands
{
    public class UpdateCustomerCommand : IRequest<bool>
    {
        public UpdateCustomerCommand(CustomerModel? customerModel)
        {
            this.customerModel = customerModel;
        }
        public CustomerModel? customerModel { get; set; }
    }
}
