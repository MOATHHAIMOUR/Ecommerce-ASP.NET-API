using Ecommerce.Application.Common.ResultPattern;
using Ecommerce.Application.DTOs.ProductDtos;
using System.Collections.Generic;

namespace Ecommerce.Application.Services.Interfaces
{
    public interface IProductServices
    {
        public Task<Result<List<ProductDto>>> GetAllProduts(Dictionary<string,string> filters, Dictionary<string,string> orders,int pageNumber,int PageSize);

        public Task<Result<ProductDto?>> GetProductById(int ProductId);


    }
}
