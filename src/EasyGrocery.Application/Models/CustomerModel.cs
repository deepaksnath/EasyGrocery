using MediatR;

namespace EasyGrocery.Application.Models
{
    public class CustomerModel : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool HasLoyaltyMembership { get; set; } = false; 
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
