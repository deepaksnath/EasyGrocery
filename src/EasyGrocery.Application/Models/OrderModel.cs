using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGrocery.Application.Models
{
    public class OrderModel 
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }       
        public bool IsLoyaltyMembershipAdded { get; set; }
    }
}
