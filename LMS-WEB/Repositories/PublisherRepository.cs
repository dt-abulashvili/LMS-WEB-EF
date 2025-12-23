using LMS_WEB.Data;
using LMS_WEB.Models;
using LMS_WEB.Repositories.Interfaces;

namespace LMS_WEB.Repositories;

internal class PublisherRepository : GenericRepository<Publisher>, IGenericRepository<Publisher>
{
    private readonly AppDbContext _dbContext;

    public PublisherRepository(AppDbContext context) : base(context)
    {
        _dbContext = context;
    }
}