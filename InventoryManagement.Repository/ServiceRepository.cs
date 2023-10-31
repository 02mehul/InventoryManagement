using InventoryManagement.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace InventoryManagement.Repository
{
    public static class ServiceRepository
    {
        public static IServiceCollection AddDataRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CIDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("CIDBContext"), sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                });
            });
            services.AddTransient(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            return services;
        }
    }
}
