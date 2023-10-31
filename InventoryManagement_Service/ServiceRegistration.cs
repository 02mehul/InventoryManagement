using InventoryManagement.Service.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Repository;

namespace InventoryManagement.Service
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            services.AddTransient<IProductService, ProductService>();
            services.AddDataRepository(configuration);
            return services;
        }
    }
}
