using Microsoft.EntityFrameworkCore;
using Said_Store.Domain.Entities;

namespace Said_Store.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book>? Books { get; set; }
        public DbSet<Buyer>? Buyers { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderItem>? OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>().HasKey(b => b.Id);
            builder.Entity<Buyer>().HasKey(b => b.Id);
            builder.Entity<Order>().HasKey(o => o.Id);
            builder.Entity<OrderItem>().HasKey(oi => oi.Id);

            builder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);

            builder.Entity<OrderItem>()
                .HasOne(oi => oi.Book)
                .WithMany()
                .HasForeignKey(oi => oi.BookId);

            builder.Entity<Buyer>()
                .HasMany(b => b.Orders)
                .WithOne(o => o.Buyer)
                .HasForeignKey(o => o.BuyerId);

            base.OnModelCreating(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=mydatabase.db");
        }
    }
}
