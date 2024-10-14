using Ecommerce.Domain.Entites.Base;

namespace Ecommerce.Domain.Entites
{
    public class Shipping : IEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public required string Carrier { get; set; }
        public required string TrackingNumber { get; set; }
        public required string Status { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }
        public required string Notes { get; set; }


        public Order Order { get; set; }

    }
}
