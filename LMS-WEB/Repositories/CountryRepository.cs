using LMS_WEB.Data;
using LMS_WEB.Models;
using LMS_WEB.Repositories.Interfaces;

namespace LMS_WEB.Repositories;

internal class CountryRepository : GenericRepository<Country>, IGenericRepository<Country>
{
    private readonly AppDbContext _dbContext;

    public CountryRepository(AppDbContext context) : base(context)
    {
        _dbContext = context;
    }
}
