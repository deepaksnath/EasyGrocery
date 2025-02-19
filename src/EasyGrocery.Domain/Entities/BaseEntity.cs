using System.ComponentModel.DataAnnotations;

namespace EasyGrocery.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
