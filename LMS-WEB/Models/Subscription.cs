namespace LMS_WEB.Models;

public class Subscription
{
    public int SubscriptionID { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsCancelled { get; set; }

    // Customer
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    // One-to-one
    public Borrowing? Borrowing { get; set; }
}
