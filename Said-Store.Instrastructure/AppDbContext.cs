using Microsoft.EntityFrameworkCore;
using Said_Store.Domain;

namespace Said_Store.Infrastructure
{
    public class AppDbContext
    {
            public class MyDbContext : AppDbContext
            {
                public DbSet<Product>? Products { get; set; }

                protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                {
                    optionsBuilder.UseSqlite("Data Source=mydatabase.db");
                }
            }

        }
}
