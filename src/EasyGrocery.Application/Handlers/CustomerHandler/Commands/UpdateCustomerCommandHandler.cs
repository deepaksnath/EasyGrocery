using EasyGrocery.Domain.Entities;
using EasyGrocery.Domain.Repositories;
using MediatR;

namespace EasyGrocery.Application.Handlers.CustomerHandler.Commands
{
    public class UpdateCustomerCommandHandler(ICustomerRepository customerRepository) :
                 IRequestHandler<UpdateCustomerCommand, Customer?>
    {
        public async Task<Customer?> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            Customer customer = new()
            {
                Id = command.Id,
                Name = command.Name,
                Email = command.Email,
                Phone = command.Phone,
                HasLoyaltyMembership = command.HasLoyaltyMembership
            };
            Customer? newCustomer = await customerRepository.UpdateCustomers(customer);

            return newCustomer;
        }
    }
}
