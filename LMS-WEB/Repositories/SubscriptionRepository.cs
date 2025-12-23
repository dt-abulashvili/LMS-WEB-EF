using LMS_WEB.Data;
using LMS_WEB.Models;
using LMS_WEB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Repositories;

internal class SubscriptionRepository : GenericRepository<Subscription>, ISubscriptionRepository
{
    private readonly AppDbContext _dbContext;

    public SubscriptionRepository(AppDbContext context) : base(context)
    {
        _dbContext = context;
    }

    public async Task CancelAsync(int subscriptionId)
    {
        var subscription = await _dbContext.Subscriptions.FirstOrDefaultAsync(s => s.SubscriptionID == subscriptionId);

        if (subscription == null)
            throw new InvalidOperationException("Subscription not found");

        if (subscription.IsCancelled)
            return;

        subscription.IsCancelled = true;
    }

    public async Task<IEnumerable<Subscription>> GetByCustomerAsync(int customerId)
    {
        return await _dbContext.Subscriptions.Where(s => s.CustomerId == customerId).ToListAsync();
    }

    public async Task<bool> HasActiveSubscriptionAsync(int customerId)
    {
        return await _dbContext.Subscriptions.AnyAsync(s => s.CustomerId == customerId && !s.IsCancelled);
    }
}
