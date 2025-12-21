using LMS_WEB.Models;

namespace LMS_WEB.Repositories.Interfaces;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAllAsync();
    Task<Author?> GetByIdAsync(int id);

    Task<Author?> GetWithBooksAsync(int id);

    Task AddAsync(Author author);
    Task UpdateAsync(Author author);
    Task SoftDeleteAsync(int id);
}

