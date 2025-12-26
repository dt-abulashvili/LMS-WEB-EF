using LMS_WEB.Models;
using System.Linq.Expressions;

namespace LMS_WEB.Repositories.Interfaces;

public interface IBookRepository : IGenericRepository<Book>
{
    Task<IEnumerable<Book>> FilterAsync(string? title, int? authorId, int? genreId, int? publisherId);
    Task<IEnumerable<Book>> WhereAsync(Expression<Func<Book, bool>> predicate);
}
