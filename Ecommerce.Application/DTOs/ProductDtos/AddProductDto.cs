namespace Ecommerce.Application.DTOs.ProductDtos
{
    public class AddProductDto
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required decimal Price { get; set; }
        public required int QuantityInStock { get; set; }
        public required string Status { get; set; }
        public required int CategoryId { get; set; }
        public required DateTime TimeAdded { get; set; }

    }
}
