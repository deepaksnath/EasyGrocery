using EasyGrocery.Domain.Entities;
using EasyGrocery.Domain.Repositories;
using MediatR;

namespace EasyGrocery.Application.Handlers.CustomerHandler.Commands
{
    public class DeleteCustomerCommandHandler(ICustomerRepository customerRepository) :
        IRequestHandler<DeleteCustomerCommand, Customer?>
    {
        public async Task<Customer?> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            return await customerRepository.DeleteCustomer(request.Id);
        }
    }
}
