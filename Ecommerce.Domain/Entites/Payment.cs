using Ecommerce.Domain.Entites.Base;
using Ecommerce.Domain.Entites.Identity;

namespace Ecommerce.Domain.Entites
{
    public class Payment : IEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public string Method { get; set; }
        public DateTime TimeStamp { get; set; }


        public Order Order { get; set; }
        public User User { get; set; }

    }
}
