using EasyGrocery.Application.Models;
using MediatR;

namespace EasyGrocery.Application.Handlers.CustomerHandler.Commands
{
    public class AddCustomerCommand : IRequest<Guid>
    {
        public AddCustomerCommand(CustomerModel? customerModel)
        {
            this.customerModel = customerModel;
        }
        public CustomerModel? customerModel {  get; set; }
    }
}
