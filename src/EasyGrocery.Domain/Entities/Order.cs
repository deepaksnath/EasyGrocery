using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGrocery.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        [NotMapped]
        public bool IsLoyaltyMembershipAdded { get; set; }
    }
}
