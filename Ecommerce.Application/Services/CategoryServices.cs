using Ecommerce.Application.Common.ResultPattern;
using Ecommerce.Application.DTOs.CategoryDtos;
using Ecommerce.Application.Services.Interfaces;
using Ecommerce.Domain.IRepositories;
using System.Collections.Generic;

namespace Ecommerce.Application.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryServices(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<List<CategoryDTO>>> GetAllCategoriesAsync()
        {
           return Result<List<CategoryDTO>>.Success(await _categoryRepository.GetAll<CategoryDTO>());  
        }
    }
}
