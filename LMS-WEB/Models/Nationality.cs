namespace LMS_WEB.Models;

public class Nationality
{
    public int NationalityID { get; set; }
    public string Name { get; set; } = null!;

    // Relationship with Authors
    public ICollection<Author> Authors { get; set; } = new List<Author>();

    // Relationship with Customers
    public ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
