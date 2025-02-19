﻿using MediatR;

namespace EasyGrocery.Application.Handlers.CustomerHandler.Commands
{
    public class AddCustomerCommand : IRequest<Guid>
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool HasLoyaltyMembership { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
