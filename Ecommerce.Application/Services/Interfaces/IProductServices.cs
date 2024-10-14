using Ecommerce.Application.Common.ResultPattern;
using Ecommerce.Application.DTOs.ProductDtos;

namespace Ecommerce.Application.Services.Interfaces
{
    public interface IProductServices
    {
        public Task<Result<List<ProductDto>>> GetAllProduts(int pageNumber,int pageSize);

        public Task<Result<ProductDto?>> GetProductById(int ProductId);


    }
}
