using Ecommerce.Application.Common.ApiResponse;
using Ecommerce.Application.DTOs.ProductDtos;
using Ecommerce.Application.Services.Interfaces;
using MediatR;

namespace Ecommerce.Application.Features.Product.Queries.GetAllProductsQuery
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ApiResponse<List<ProductDto>>>
    {
        private readonly IProductServices _productServices;

        public GetAllProductsQueryHandler(IProductServices productServices)
        {
            _productServices = productServices;
        }

        public async Task<ApiResponse<List<ProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {

            var result = await _productServices.GetAllProduts();

            return ApiResponseHandler.Success(
                data: result.Value ?? [],
                meta: new { count = result.Value?.Count ?? 0 }
            );
        }
    }
}
