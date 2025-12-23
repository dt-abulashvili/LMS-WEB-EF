using LMS_WEB.Data;
using LMS_WEB.Models;
using LMS_WEB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Repositories;

internal class AuthorRepository : GenericRepository<Author>, IAuthorRepository
{
    private readonly AppDbContext _dbContext;

    public AuthorRepository(AppDbContext context) : base(context)
    {
        _dbContext = context;
    }

    public async Task<Author?> GetWithBooksAsync(int id)
    {
        return await _dbContext.Authors
            .Include(b => b.Books)
            .FirstOrDefaultAsync(a => a.AuthorID == id);
    }

    public async Task<IEnumerable<Author>> GetAllWithBooksAsync()
    {
        return await _dbContext.Authors
            .Include(a => a.Books)
            .Include(a => a.City)
            .Include(a => a.Nationality)
            .ToListAsync();
    }
}
