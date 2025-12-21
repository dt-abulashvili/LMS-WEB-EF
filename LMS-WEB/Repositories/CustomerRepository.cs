using LMS_WEB.Data;
using LMS_WEB.Models;
using LMS_WEB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _dbContext;

    public CustomerRepository(AppDbContext context)
    {
        _dbContext = context;
    }
    public async Task AddAsync(Customer customer)
    {
        await _dbContext.Customers.AddAsync(customer);
    }

    public async Task SoftDeleteAsync(int id)
    {
        var customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.CustomerID == id);
        if (customer == null)
            return;

        customer.IsDeleted = true;
    }
    public async Task UpdateAsync(Customer customer)
    {
        var existingCustomer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.CustomerID == customer.CustomerID);
        if (existingCustomer == null) 
            return;

        var IsDeleted = existingCustomer.IsDeleted;

        _dbContext.Entry(existingCustomer).CurrentValues.SetValues(customer);
        existingCustomer.IsDeleted = IsDeleted;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _dbContext.Customers.ToListAsync();
    }

    public async Task<Customer?> GetByIdAsync(int id)
    {
        return await _dbContext.Customers.FirstOrDefaultAsync(c => c.CustomerID == id);
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
