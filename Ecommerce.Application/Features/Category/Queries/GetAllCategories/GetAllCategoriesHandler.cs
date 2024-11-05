using Ecommerce.Application.Common.ApiResponse;
using Ecommerce.Application.DTOs.CategoryDtos;
using Ecommerce.Application.Services.Interfaces;
using Ecommerce.Domain.IRepositories;
using MediatR;

namespace Ecommerce.Application.Features.Category.Queries.GetAllCategories
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, ApiResponse<List<CategoryDTO>>>
    {
        private readonly ICategoryServices _categoryServices;

        public GetAllCategoriesHandler(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public async Task<ApiResponse<List<CategoryDTO>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryServices.GetAllCategoriesAsync();

            return ApiResponseHandler.Success<List<CategoryDTO>>(categories.Value, new { count = categories.Value.Count});
        }
    }
}
