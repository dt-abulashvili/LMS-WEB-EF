namespace LMS_WEB.Models;

public class Borrowing
{
    public int BorrowingId { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public bool IsOver { get; set; }

    // Relationship with Customer   
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    // Optional subscription
    public int? SubscriptionID { get; set; }
    public Subscription? Subscription { get; set; }

    // Many-to-many
    public ICollection<Book> Books { get; set; } = new List<Book>(); 

}
