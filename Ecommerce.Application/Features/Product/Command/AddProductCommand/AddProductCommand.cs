using Ecommerce.Application.DTOs.ProductDtos;
using MediatR;

namespace Ecommerce.Application.Features.Product.Command.AddProductCommand
{
    public class AddProductCommand : IRequest<int> // Returning the product ID after creation
    {
        public required AddProductDto AddProductDto { get; set; }

    }
}
