using AutoMapper;
using EasyGrocery.Domain.Entities;
using EasyGrocery.Domain.Repositories;
using MediatR;

namespace EasyGrocery.Application.Handlers.CustomerHandler.Commands
{
    public class UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper) :
                 IRequestHandler<UpdateCustomerCommand, bool>
    {
        public async Task<bool> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            Customer customer = mapper.Map<Customer>(command.CustomerModel);
            bool response = await customerRepository.UpdateCustomers(customer);

            return response;
        }
    }
}
