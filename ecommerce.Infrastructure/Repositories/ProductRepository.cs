using AutoMapper;
using Ecommerce.Infrastructure.Data;
using Ecommerce.Infrastructure.Repositories.Base;
using Ecommerce.Domain.Entites;
using Ecommerce.Domain.IRepositories;

namespace Ecommerce.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
