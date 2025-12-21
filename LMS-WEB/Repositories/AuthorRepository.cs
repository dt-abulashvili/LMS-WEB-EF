using LMS_WEB.Data;
using LMS_WEB.Models;
using LMS_WEB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly AppDbContext _dbContext;

    public AuthorRepository(AppDbContext context)
    {
        _dbContext = context;
    }
    public async Task AddAsync(Author author)
    {
        await _dbContext.Authors.AddAsync(author);
    }

    public async Task SoftDeleteAsync(int id)
    {
        var author = await _dbContext.Authors.FirstOrDefaultAsync(a => a.AuthorID == id);
        if (author == null)
            return;

        author.IsDeleted = true;
    }

    public async Task UpdateAsync(Author author)
    {
        var existingAuthor = await _dbContext.Authors.FirstOrDefaultAsync(a => a.AuthorID == author.AuthorID);
        if (existingAuthor == null)
            return;

        var isDeleted = existingAuthor.IsDeleted;

        _dbContext.Entry(existingAuthor).CurrentValues.SetValues(author);
        existingAuthor.IsDeleted = isDeleted;
    }

    public async Task<IEnumerable<Author>> GetAllAsync()
    {
        return await _dbContext.Authors.ToListAsync();   
    }

    public async Task<Author?> GetByIdAsync(int id)
    {
        return await _dbContext.Authors.FirstOrDefaultAsync(a => a.AuthorID == id);
    }

    public async Task<Author?> GetWithBooksAsync(int id)
    {
        return await _dbContext.Authors
            .Include(b => b.Books)
            .FirstOrDefaultAsync(a => a.AuthorID == id);
    }
}
