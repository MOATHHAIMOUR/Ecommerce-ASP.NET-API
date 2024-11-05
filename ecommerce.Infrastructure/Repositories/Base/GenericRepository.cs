using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ecommerce.Infrastructure.Data;
using Ecommerce.Domain.IRepositories.Base;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Infrastructure.Extentions;

namespace Ecommerce.Infrastructure.Repositories.Base
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class 
    {
        private DbSet<TEntity> Entity { set; get; }
        private AppDbContext Context { set; get; } 
        private IMapper Mapper {  get; set; }   
        
        public GenericRepository(AppDbContext context, IMapper mapper)
        {
            Entity = context.Set<TEntity>();
            Context = context;
            Mapper = mapper; 
        }


        public async Task<List<TEntity>> GetAllPaginatedAsync(int pageNumber, int pageSize, Dictionary<string, string> filters, Dictionary<string, string> orders)
        {
            return await Entity.AsNoTracking()
                     .CustomFiltring(filters)
                     .CustomOrdring(orders)
                     .CustomPagination(pageNumber, pageSize)
                     .ToListAsync();
        }

        public async Task<List<DTO>> GetAllPaginatedAsync<DTO>(int pageNumber,int pageSize,Dictionary<string,string> filters, Dictionary<string, string> orders ) where DTO : class
        {
            var query = Entity.AsNoTracking()
            .CustomFiltring(filters)
            .ProjectTo<DTO>(Mapper.ConfigurationProvider)
            .CustomOrdring(orders)
            .CustomPagination(pageNumber, pageSize);
                    

            return await query.ToListAsync(); 
        }

        public async Task<List<DTO>> GetAll<DTO>() where DTO : class
        {
            var query = Entity.AsNoTracking()
            .ProjectTo<DTO>(Mapper.ConfigurationProvider); 

            return await query.ToListAsync();
        }

        public async Task<TEntity?> GetById(int Id)
        {
            return await Entity.AsNoTracking()
                .Where(e => EF.Property<int>(e, "Id") == Id)
                .FirstOrDefaultAsync(); 
        }
       
        public async Task<DTO?> GetById<DTO>(int Id)
        {
            return await Entity.AsNoTracking()
                           .Where(e => EF.Property<int>(e, "Id") == Id)
                           .ProjectTo<DTO>(Mapper.ConfigurationProvider)
                           .FirstOrDefaultAsync();
        }

        public async Task<int> Add(TEntity entity)
        {
            await Entity.AddAsync(entity);
            await Context.SaveChangesAsync();  
            return (int)(typeof(TEntity).GetProperty("Id")?.GetValue(entity) ?? 0);
        }

        public async Task<bool> Delete(TEntity entity)
        {
            Entity.Remove(entity);
            
            int numbweOfRowsAffected = await Context.SaveChangesAsync();

            return numbweOfRowsAffected > 0;
        }

        public async Task<bool> Update(TEntity entity)
        {
            Entity.Update(entity);
            int numbweOfRowsAffected = await Context.SaveChangesAsync();
            return numbweOfRowsAffected > 0;
        }
    }
}
