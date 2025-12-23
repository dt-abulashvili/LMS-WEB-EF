using LMS_WEB.Data;
using LMS_WEB.Models;

namespace LMS_WEB.Repositories;

internal class GenreRepository : GenericRepository<Genre>
{
    private readonly AppDbContext _dbContext;

    public GenreRepository(AppDbContext context) : base(context)
    {
        _dbContext = context;
    }
}
