namespace EasyGrocery.Domain.Entities
{
    public class CartItem : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
