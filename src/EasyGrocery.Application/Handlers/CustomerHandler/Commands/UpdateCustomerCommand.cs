using EasyGrocery.Domain.Entities;
using MediatR;

namespace EasyGrocery.Application.Handlers.CustomerHandler.Commands
{
    public class UpdateCustomerCommand : IRequest<Customer>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool HasLoyaltyMembership { get; set; }
    }
}
