using AutoMapper;
using Ecommerce.Domain.Entites;
using Ecommerce.Domain.IRepositories;
using Ecommerce.Infrastructure.Data;
using Ecommerce.Infrastructure.Repositories.Base;

namespace Ecommerce.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
