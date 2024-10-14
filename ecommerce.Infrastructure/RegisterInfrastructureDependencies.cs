using Ecommerce.Infrastructure.Data;
using Ecommerce.Infrastructure.Repositories;
using Ecommerce.Infrastructure.Repositories.Base;
using Ecommerce.Domain.IRepositories;
using Ecommerce.Domain.IRepositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Infrastructure
{
    public static class RegisterInfrastructureDependencies
    {

        public static IServiceCollection InfrastructureDependencies(this IServiceCollection services,IConfiguration configuration)
        {

            // Add SQL DB In DI Container
            services.AddDbContext<AppDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("SQLServer")));
    



            // Add All Repositories In DI Container
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();



            return services;    
        }

    }
}
