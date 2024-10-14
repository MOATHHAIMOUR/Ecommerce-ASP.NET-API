namespace Ecommerce.Application.DTOs.ProductDtos
{
    public class ProductDto
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public required decimal Price { get; set; }

        public required int Quantity { get; set; }

        public required bool IsAvailable { get; set; }

        
    }
}
