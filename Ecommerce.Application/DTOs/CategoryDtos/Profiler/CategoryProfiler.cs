using AutoMapper;
using Ecommerce.Domain.Entites;

namespace Ecommerce.Application.DTOs.CategoryDtos.Profiler
{
    public class CategoryProfiler : Profile
    {
        public CategoryProfiler()
        {
            CreateMap<Category,CategoryDTO>();  
        }
    }
}
