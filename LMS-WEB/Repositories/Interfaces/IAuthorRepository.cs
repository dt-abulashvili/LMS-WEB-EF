using LMS_WEB.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Repositories.Interfaces;

public interface IAuthorRepository : IGenericRepository<Author>
{
    Task<IEnumerable<Author>> GetAllWithBooksAsync();
    Task<Author?> GetAuthorWithBooks(int id);
}

