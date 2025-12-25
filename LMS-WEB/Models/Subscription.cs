using LMS_WEB.Models.Interfaces;

namespace LMS_WEB.Models;

public class Subscription : ISoftDeletable
{
    public int SubscriptionID { get; set; }
    public DateTime StartDate { get; set; }
    public SubscriptionPeriod Period { get; set; }

    public bool IsCancelled { get; set; }
    public bool IsDeleted { get; set; }

    // Customer
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    // One-to-one
    public Borrowing? Borrowing { get; set; }

    [NotMapped]
    public DateTime EndDate => Period switch
    {
        SubscriptionPeriod.Week => StartDate.AddDays(7),
        SubscriptionPeriod.Month => StartDate.AddMonths(1),
        SubscriptionPeriod.Year => StartDate.AddYears(1),
        _ => throw new InvalidOperationException("Invalid subscription period")
    };
}

public enum SubscriptionPeriod
{
    Week = 1,
    Month = 2,
    Year = 3
}
