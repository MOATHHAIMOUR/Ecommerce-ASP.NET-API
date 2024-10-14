using Ecommerce.Domain.Entites.Base;
using Ecommerce.Domain.Entites.Identity;

namespace Ecommerce.Domain.Entites
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public TimeSpan OrderTime { get; set; }
        public decimal OrderPrice { get; set; }
        public string Status { get; set; }


        public User User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public Shipping Shipping { get; set; }
        public Payment Payment { get; set; }
    }
}
