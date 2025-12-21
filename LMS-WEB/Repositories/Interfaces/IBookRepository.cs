using LMS_WEB.Models;

namespace LMS_WEB.Repositories.Interfaces;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllAsync();
    Task<Book?> GetByIdAsync(int id);

    Task<Book?> GetWithDetailsAsync(int id);
    // Authors + Genres + Publisher

    Task<IEnumerable<Book>> GetByGenreAsync(int genreId);
    Task<IEnumerable<Book>> GetByAuthorAsync(int authorId);
    Task<IEnumerable<Book>> SearchAsync(string title);

    Task AddAsync(Book book);
    Task UpdateAsync(Book book);
    Task SoftDeleteAsync(int id);
}
