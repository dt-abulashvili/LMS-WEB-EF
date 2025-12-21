using LMS_WEB.Data;
using LMS_WEB.Models;
using LMS_WEB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Repositories;

public class BookRepository : IBookRepository
{
    private readonly AppDbContext _dbContext;

    public BookRepository(AppDbContext context)
    {
        _dbContext = context;
    }

    public async Task AddAsync(Book book)
    {
        await _dbContext.Books.AddAsync(book);
    }

    public async Task SoftDeleteAsync(int id)
    {
        var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.BookID == id);
        if (book == null)
            return;

        book.IsDeleted = true;
    }

    public async Task UpdateAsync(Book book)
    {
        var existingBook = await _dbContext.Books.FirstOrDefaultAsync(b => b.BookID == book.BookID);
        if (existingBook == null)
            return;

        var isDeleted = existingBook.IsDeleted;

        _dbContext.Entry(existingBook).CurrentValues.SetValues(book);
        existingBook.IsDeleted = isDeleted;
    }


    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _dbContext.Books.ToListAsync();
    }

    public async Task<IEnumerable<Book>> GetByAuthorAsync(int authorId)
    {
        return await _dbContext.Books.Where(b => b.Authors.Any(a => a.AuthorID == authorId)).ToListAsync();
    }

    public async Task<IEnumerable<Book>> GetByGenreAsync(int genreId)
    {
        return await _dbContext.Books.Where(b => b.Genres.Any(g => g.GenreID == genreId)).ToListAsync();
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        return await _dbContext.Books.FirstOrDefaultAsync(b => b.BookID == id);
    }

    // Authors + Genres + Publisher
    public async Task<Book?> GetWithDetailsAsync(int id)
    {
        return await _dbContext.Books
            .Include(b => b.Authors)
            .Include(b => b.Genres)
            .Include(b => b.Publisher)
            .FirstOrDefaultAsync(b => b.BookID == id);
    }

    public async Task<IEnumerable<Book>> SearchAsync(string title)
    {
        return await _dbContext.Books
            .Where(b => EF.Functions.Like(b.Title, $"%{title}%"))
            .ToListAsync();
    }
}
