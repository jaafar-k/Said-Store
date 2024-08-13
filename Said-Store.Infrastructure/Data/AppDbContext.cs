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
            builder.Entity<Book>().HasData(
    new Book(1, "The Great Gatsby", "F. Scott Fitzgerald", "Fiction", 1925, 10.99m, "A classic novel of the Roaring Twenties."),
    new Book(2, "To Kill a Mockingbird", "Harper Lee", "Fiction", 1960, 7.99m, "A novel of warmth and humor despite dealing with serious issues of race and rape."),
    new Book(3, "1984", "George Orwell", "Adventure", 1949, 8.99m, "A novel depicting a totalitarian society controlled by Big Brother."),
    new Book(4, "Moby Dick", "Herman Melville", "Adventure", 1851, 11.50m, "A seafaring adventure about obsession and revenge."),
    new Book(5, "War and Peace", "Leo Tolstoy", "Historical", 1869, 12.99m, "A historical novel that chronicles the French invasion of Russia."),
    new Book(6, "Pride and Prejudice", "Jane Austen", "Romance", 1813, 9.99m, "A romantic novel that critiques the British landed gentry at the end of the 18th century."),
    new Book(7, "The Catcher in the Rye", "J.D. Salinger", "Fiction", 1951, 6.99m, "A story about teenage angst and alienation."),
    new Book(8, "The Hobbit", "J.R.R. Tolkien", "Fantasy", 1937, 8.50m, "A fantasy novel and children's book about Bilbo Baggins's quest."),
    new Book(9, "Crime and Punishment", "Fyodor Dostoevsky", "Philosophical", 1866, 10.75m, "A novel that explores the psychological effects of crime and punishment."),
    new Book(10, "The Odyssey", "Homer", "Fantasy", -800, 14.00m, "An epic poem about the journey of Odysseus back home after the Trojan War.")
);

            base.OnModelCreating(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=mydatabase.db");
        }
    }
}
