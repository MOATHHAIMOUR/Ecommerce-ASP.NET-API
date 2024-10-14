using Ecommerce.Domain.Entites.Base;

namespace Ecommerce.Domain.Entites
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required decimal Price { get; set; }
        public required int QuantityInStock { get; set; }
        public required  ProductStatus Status { get; set; }
        public required int CategoryId { get; set; }
        public required DateTime TimeAdded { get; set; }



        public  Category Category { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }


    public enum ProductStatus
    {
        Available,
        OutOfStock
    }


}
