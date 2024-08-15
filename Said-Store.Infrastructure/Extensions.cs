using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Said_Store.Application.Repositories;
using Said_Store.Infrastructure.Data;
using Said_Store.Infrastructure.Data.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Said_Store.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(connectionString, b => b.MigrationsAssembly("Said-Store")));

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IBuyerRepository, BuyerRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();

            return services;
        }        
    }
}
