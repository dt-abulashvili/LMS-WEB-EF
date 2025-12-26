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

    public async Task<IEnumerable<Subscription>> FilterAsync(int? customerId, SubscriptionStatus? status)
    {
        var query = _dbContext.Subscriptions.AsQueryable();

        if (customerId.HasValue)
            query = query.Where(c => c.CustomerId == customerId);

        if (status.HasValue)
        {
            var now = DateTime.UtcNow;

            query = status.Value switch
            {
                SubscriptionStatus.Active =>
                    query.Where(s =>
                        !s.IsCancelled &&
                        (
                            (s.Period == SubscriptionPeriod.Week && s.StartDate.AddDays(7) >= now) ||
                            (s.Period == SubscriptionPeriod.Month && s.StartDate.AddMonths(1) >= now) ||
                            (s.Period == SubscriptionPeriod.Year && s.StartDate.AddYears(1) >= now)
                        )
                    ),

                SubscriptionStatus.Expired =>
                    query.Where(s =>
                        !s.IsCancelled &&
                        (
                            (s.Period == SubscriptionPeriod.Week && s.StartDate.AddDays(7) < now) ||
                            (s.Period == SubscriptionPeriod.Month && s.StartDate.AddMonths(1) < now) ||
                            (s.Period == SubscriptionPeriod.Year && s.StartDate.AddYears(1) < now)
                        )
                    ),

                SubscriptionStatus.Cancelled =>
                    query.Where(s => s.IsCancelled),

                _ => query
            };
        }

        return await query
            .Include(c => c.Customer)
            .ToListAsync();
    }
}
