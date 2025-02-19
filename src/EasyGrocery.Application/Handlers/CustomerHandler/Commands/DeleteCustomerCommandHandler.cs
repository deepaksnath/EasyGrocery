using EasyGrocery.Domain.Repositories;
using MediatR;

namespace EasyGrocery.Application.Handlers.CustomerHandler.Commands
{
    public class DeleteCustomerCommandHandler(ICustomerRepository customerRepository) :
        IRequestHandler<DeleteCustomerCommand, bool>
    {
        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            return await customerRepository.DeleteCustomer(request.Id);
        }
    }
}
