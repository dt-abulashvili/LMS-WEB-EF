using LMS_WEB.Models.Interfaces;

namespace LMS_WEB.Models;

public class Borrowing : ISoftDeletable
{
    public int BorrowingId { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public bool IsOver { get; set; }
    public bool IsDeleted { get; set; }

    // Relationship with Customer   
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    // Optional subscription
    public int? SubscriptionID { get; set; }
    public Subscription? Subscription { get; set; }

    // Many-to-many
    public ICollection<Book> Books { get; set; } = [];

    [NotMapped]
    public BorrowingStatus Status
    {
        get
        {
            if (IsOver)
                return BorrowingStatus.Completed;

            if (DueDate.HasValue && DateTime.UtcNow > DueDate.Value)
                return BorrowingStatus.Expired;

            return BorrowingStatus.Active;
        }
    }
}

public enum BorrowingStatus
{
    Active,
    Expired,
    Completed
}
