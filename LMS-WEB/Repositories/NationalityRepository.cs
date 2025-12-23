using LMS_WEB.Data;
using LMS_WEB.Models;
using LMS_WEB.Repositories.Interfaces;

namespace LMS_WEB.Repositories;

internal class NationalityRepository : GenericRepository<Nationality>, IGenericRepository<Nationality>
{
    private readonly AppDbContext _dbContext;

    public NationalityRepository(AppDbContext context) : base(context)
    {
        _dbContext = context;
    }
}
