using Ecommerce.Application.Common.Erros;
using Ecommerce.Application.Common.ResultPattern;
using Ecommerce.Application.DTOs.ProductDtos;
using Ecommerce.Application.Services.Interfaces;
using Ecommerce.Domain.IRepositories;

namespace Ecommerce.Application.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;
        
        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<List<ProductDto>>> GetAllProduts(int pageNumber, int pageSize)
        {
            return Result<List<ProductDto>>.Success(await _productRepository.GetAllPaginatedAsync<ProductDto>(pageNumber, pageSize));
        }

        public async Task<Result<ProductDto?>> GetProductById(int ProductId)
        {
            ProductDto? product =  await _productRepository.GetById<ProductDto>(ProductId);

            if (product is null)
                return Result<ProductDto?>.Failure(Error.RecoredNotFound($"Product with id: {ProductId} is not found"));

            return Result<ProductDto?>.Success(product);
        }
    }
}
