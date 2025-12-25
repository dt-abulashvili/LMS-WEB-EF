using LMS_WEB.Models;

namespace LMS_WEB.Repositories.Interfaces;

public interface ISubscriptionRepository : IGenericRepository<Subscription>
{
    Task<IEnumerable<Subscription>> FilterAsync(int? customerId, bool? status);
    Task CancelAsync(int subscriptionId);
}

