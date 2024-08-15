using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MediatR;
using Said_Store.Infrastructure;
using Said_Store.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Said_Store.Application.Repositories;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
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

builder.Services.AddDatabase();

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
