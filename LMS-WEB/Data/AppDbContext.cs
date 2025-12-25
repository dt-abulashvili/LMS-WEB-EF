using LMS_WEB.Models;
using Microsoft.EntityFrameworkCore;

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

        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorID)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Book>()
            .HasOne(b => b.Publisher)
            .WithMany(p => p.Books)
            .HasForeignKey(b => b.PublisherId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Book>()
            .HasOne(b => b.Genre)
            .WithMany(g => g.Books)
            .HasForeignKey(b => b.GenreID)
            .OnDelete(DeleteBehavior.Restrict);

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
