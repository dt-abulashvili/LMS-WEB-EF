using Microsoft.EntityFrameworkCore;
using LMS_WEB.Models;

namespace LMS_WEB.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Nationality> Nationalities { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Borrowing> Borrowings { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Book - Author
        modelBuilder.Entity<Book>()
            .HasMany(b => b.Authors)
            .WithMany(a => a.Books)
            .UsingEntity<Dictionary<string, object>>(
                "AuthorBook",
                j => j
                    .HasOne<Author>()
                    .WithMany()
                    .HasForeignKey("AuthorId")
                    .OnDelete(DeleteBehavior.Restrict),
                j => j
                    .HasOne<Book>()
                    .WithMany()
                    .HasForeignKey("BookId")
                    .OnDelete(DeleteBehavior.Restrict)
            );

        // Book - Genre
        modelBuilder.Entity<Book>()
            .HasMany(b => b.Genres)
            .WithMany(g => g.Books)
            .UsingEntity<Dictionary<string, object>>(
                "BookGenre",
                j => j
                    .HasOne<Genre>()
                    .WithMany()
                    .HasForeignKey("GenreId")
                    .OnDelete(DeleteBehavior.Restrict),
                j => j
                    .HasOne<Book>()
                    .WithMany()
                    .HasForeignKey("BookId")
                    .OnDelete(DeleteBehavior.Restrict)
            );

        // Borrowing - Book
        modelBuilder.Entity<Borrowing>()
            .HasMany(br => br.Books)
            .WithMany(b => b.Borrowings)
            .UsingEntity<Dictionary<string, object>>(
                "BorrowingBook",
                j => j
                    .HasOne<Book>()
                    .WithMany()
                    .HasForeignKey("BookId")
                    .OnDelete(DeleteBehavior.Restrict),
                j => j
                    .HasOne<Borrowing>()
                    .WithMany()
                    .HasForeignKey("BorrowingId")
                    .OnDelete(DeleteBehavior.Restrict)
            );

        modelBuilder.Entity<Book>()
            .HasQueryFilter(b => !b.IsDeleted);

        modelBuilder.Entity<Customer>()
            .HasQueryFilter(c => !c.IsDeleted);

        modelBuilder.Entity<Author>()
            .HasQueryFilter(a => !a.IsDeleted);

        modelBuilder.Entity<Borrowing>()
            .HasQueryFilter(a => !a.IsDeleted);

        modelBuilder.Entity<Subscription>()
            .HasQueryFilter(a => !a.IsDeleted);

        modelBuilder.Entity<Country>()
            .HasQueryFilter(a => !a.IsDeleted);

        modelBuilder.Entity<City>()
            .HasQueryFilter(a => !a.IsDeleted);

        modelBuilder.Entity<Nationality>()
            .HasQueryFilter(a => !a.IsDeleted);

        modelBuilder.Entity<Genre>()
            .HasQueryFilter(a => !a.IsDeleted);

        modelBuilder.Entity<Publisher>()
            .HasQueryFilter(a => !a.IsDeleted);
    }

}
