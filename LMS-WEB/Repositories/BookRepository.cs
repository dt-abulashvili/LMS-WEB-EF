using LMS_WEB.Data;
using LMS_WEB.Models;
using LMS_WEB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Repositories;

internal sealed class BookRepository : GenericRepository<Book>, IBookRepository
{
    private readonly AppDbContext _dbContext;

    public BookRepository(AppDbContext context) : base(context)
    {
        _dbContext = context;
    }

    // Authors + Genres + Publisher
    public async Task<Book?> GetWithDetailsAsync(int id)
    {
        return await _dbContext.Books
            .Include(b => b.Author)
            .Include(b => b.Genre)
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
