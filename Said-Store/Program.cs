using Microsoft.OpenApi.Models;
using Said_Store.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyReadingList.WebAPI", Version = "v1" });
});

var connection = builder.Configuration.GetConnectionString("SqliteConnectionString");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connection, b => b.MigrationsAssembly("Said-Store")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyReadingList.WebAPI v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
