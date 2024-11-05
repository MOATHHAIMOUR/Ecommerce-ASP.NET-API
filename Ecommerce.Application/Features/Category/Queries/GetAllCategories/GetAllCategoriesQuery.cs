using Ecommerce.Application.Common.ApiResponse;
using Ecommerce.Application.DTOs.CategoryDtos;
using MediatR;

namespace Ecommerce.Application.Features.Category.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<ApiResponse<List<CategoryDTO>>>
    {
    }
}
