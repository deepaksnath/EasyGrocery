using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGrocery.Application.Models
{
    public class OrderModel : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        [NotMapped]
        public bool IsLoyaltyMembershipAdded { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
