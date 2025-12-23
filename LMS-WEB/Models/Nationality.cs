using LMS_WEB.Models.Interfaces;

namespace LMS_WEB.Models;

public class Nationality : ISoftDeletable
{
    public int NationalityID { get; set; }
    public string Name { get; set; } = null!;
    public bool IsDeleted { get; set; }

    // Relationship with Authors
    public ICollection<Author> Authors { get; set; } = new List<Author>();

    // Relationship with Customers
    public ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
