using LMS_WEB.Data;
using LMS_WEB.Models;
using LMS_WEB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Repositories;

internal class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    private readonly AppDbContext _dbContext;

    public CustomerRepository(AppDbContext context) : base(context)
    {
        _dbContext = context;
    }

    public Task<Customer?> GetWithBorrowingsAsync(int id)
    {
        return _dbContext.Customers
            .Include(c => c.Borrowings)
            .FirstOrDefaultAsync(c => c.CustomerID == id);
    }

    public Task<Customer?> GetWithSubscriptionsAsync(int id)
    {
        return _dbContext.Customers
            .Include(c => c.Subscriptions)
            .FirstOrDefaultAsync(c => c.CustomerID == id);
    }
}
