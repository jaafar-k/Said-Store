using Microsoft.Extensions.DependencyInjection;

using Said_Store.Application.Repositories;
using Said_Store.Infrastructure.Data.Repositories;

namespace Said_Store.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }        
    }
}
