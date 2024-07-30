using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Said_Store.Infrastructure.AppDbContext;
public class Program{
public void ConfigureService(IServiceCollection services)
{
    services.AddControllers();
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyReadingList.WebAPI", Version = "v1" });
    });
    var connection = Configuration["ConnectionSqlite:SqliteConnectionString"];
    services.AddDbContext<MyDbContext>(Options.UseSqlite(Connection));
}
}