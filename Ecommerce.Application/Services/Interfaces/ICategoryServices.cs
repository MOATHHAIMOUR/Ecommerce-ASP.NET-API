using Ecommerce.Application.Common.ResultPattern;
using Ecommerce.Application.DTOs.CategoryDtos;

namespace Ecommerce.Application.Services.Interfaces
{
    public interface ICategoryServices
    {
        public Task<Result<List<CategoryDTO>>> GetAllCategoriesAsync();
    }
}
