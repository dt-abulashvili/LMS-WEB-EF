using LMS_WEB.Data;
using LMS_WEB.Models;
using LMS_WEB.Repositories.Interfaces;

namespace LMS_WEB.Repositories;

internal class CityRepository : GenericRepository<City>, IGenericRepository<City>
{
    private readonly AppDbContext _dbContext;

    public CityRepository(AppDbContext context) : base(context)
    {
        _dbContext = context;
    }
}
