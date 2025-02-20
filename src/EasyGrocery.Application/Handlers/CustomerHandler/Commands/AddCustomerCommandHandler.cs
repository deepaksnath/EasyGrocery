using EasyGrocery.Domain.Repositories;
using EasyGrocery.Domain.Entities;
using MediatR;
using AutoMapper;

namespace EasyGrocery.Application.Handlers.CustomerHandler.Commands
{
    public class AddCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper) : 
                 IRequestHandler<AddCustomerCommand, Guid>
    {
        public async Task<Guid> Handle(AddCustomerCommand command, CancellationToken cancellationToken)
        {
            Customer customer = mapper.Map<Customer>(command.CustomerModel);            
            var id = await customerRepository.AddCustomers(customer);

            return id;
        }
    }
}
