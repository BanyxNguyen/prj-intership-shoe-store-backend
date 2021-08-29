using Microsoft.Extensions.DependencyInjection;
using prjShoeStore.Respositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.Respositories.Infractures
{
    public static class ConfigureExtension
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {

            services.AddTransient<IProductRespository, ProductRespository>();
            return services;
        }
    }
}
