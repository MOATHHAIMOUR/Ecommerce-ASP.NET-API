using AutoMapper;
using Ecommerce.Domain.Entites;


namespace Ecommerce.Application.DTOs.ProductDtos.Profiler
{
    internal class ProductProfiler : Profile
    {
        public ProductProfiler()
        {
            CreateMap<Product,ProductDto>();
        }
    }
}
