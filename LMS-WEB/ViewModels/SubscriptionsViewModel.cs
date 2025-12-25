using LMS_WEB.Models;

namespace LMS_WEB.ViewModels;

public class SubscriptionsViewModel
{
    public IEnumerable<Customer> Customers { get; set; } = new List<Customer>();
    public IEnumerable<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    public DateTime StartDate { get; set; }
    public SubscriptionPeriod Period { get; set; }
}

