using Ecommerce.Application.Common.ApiResponse;
using Ecommerce.Application.DTOs.ProductDtos;
using MediatR;

namespace Ecommerce.Application.Features.Product.Queries.GetAllProductsQuery
{
    public class GetAllProductsQuery : IRequest<ApiResponse<List<ProductDto>>>
    {
        public int PageNumber { get; set; }
        public int PageCountet;
    }
}
