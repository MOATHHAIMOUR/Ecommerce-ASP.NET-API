using Ecommerce.Domain.Entites.Base;
using Ecommerce.Domain.Entites.Identity;

namespace Ecommerce.Domain.Entites
{
    public class Review : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string ? ReviewText { get; set; }
        public int Rating { get; set; }
        public DateTime TimeStamp { get; set; }



        public Product Product { get; set; }
        public User User { get; set; }

    }
}
