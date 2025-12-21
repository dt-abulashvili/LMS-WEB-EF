using LMS_WEB.Models;

namespace LMS_WEB.Repositories.Interfaces;

public interface ISubscriptionRepository
{
    Task<Subscription?> GetByIdAsync(int id);

    Task<IEnumerable<Subscription>> GetByCustomerAsync(int customerId);

    Task<bool> HasActiveSubscriptionAsync(int customerId);

    Task AddAsync(Subscription subscription);
    Task CancelAsync(int subscriptionId);
}

