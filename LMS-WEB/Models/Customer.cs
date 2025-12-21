namespace LMS_WEB.Models;

public class Customer
{
    public int CustomerID { get; set; }
    public string FullName { get; set; } = null!;
    public bool IsDeleted { get; set; }

    // Location
    public int CityID { get; set; }
    public City City { get; set; } = null!;

    public int NationalityID { get; set; }
    public Nationality Nationality { get; set; } = null!;

    // One-to-Many
    public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    public ICollection<Borrowing> Borrowings { get; set; } = new List<Borrowing>();
}
