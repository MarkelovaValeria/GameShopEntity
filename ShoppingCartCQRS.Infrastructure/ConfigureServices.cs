using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartCQRS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ShoppingCartCQRS.Domain.Interface;
using ShoppingCartCQRS.Infrastructure.Repositories;

namespace ShoppingCartCQRS.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ShoppingCartDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddTransient<IShoppingCartRepository, ShoppingCartRepository>();
            return services;
        }
    }
}
