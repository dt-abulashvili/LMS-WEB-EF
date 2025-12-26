using LMS_WEB.Models;

namespace LMS_WEB.ViewModels;

public class CustomerSubscriptionsViewModel
{
    public string CustomerName { get; set; } = null!;
    public IEnumerable<Subscription> Subscriptions { get; set; } = new List<Subscription>();
}
