using Microsoft.EntityFrameworkCore;
using Said_Store.Domain;

namespace Said_Store.Infrastructure
{
    public class AppDbContext
    {
            public class MyDbContext : AppDbContext
            {
            public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
                public DbSet<Book>? Books { get; set; }
            protected override void OnModelCreating(ModelBuilder builder)
            {
                builder.Entity<Book>().HasKey(b => b.ID);
                base.OnModelCreating(builder);
            }
                protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                {
                    optionsBuilder.UseSqlite("Data Source=mydatabase.db");
                }
            }

        }
}
