using EasyGrocery.Domain.Repositories;
using EasyGrocery.Domain.Entities;
using MediatR;

namespace EasyGrocery.Application.Handlers.CustomerHandler.Commands
{
    public class AddCustomerCommandHandler(ICustomerRepository customerRepository) : 
                 IRequestHandler<AddCustomerCommand, Customer>
    {        
        public async Task<Customer> Handle(AddCustomerCommand command, CancellationToken cancellationToken)
        {
            Customer customer = new()
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Email = command.Email,
                Phone = command.Phone,
                HasLoyaltyMembership = command.HasLoyaltyMembership
            };
            Customer newCustomer = await customerRepository.AddCustomers(customer);

            return newCustomer;
        }
    }
}
