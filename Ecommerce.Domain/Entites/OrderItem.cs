using Ecommerce.Domain.Entites.Base;

namespace Ecommerce.Domain.Entites
{
    public class OrderItem : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }


        public Product Product { get; set; }
        public Order Order { get; set; }


    }
}
