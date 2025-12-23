using LMS_WEB.Models.Interfaces;

namespace LMS_WEB.Models;

public class Publisher : ISoftDeletable
{
    public int PublisherID { get; set; }
    public string Name { get; set; } = null!;
    public bool IsDeleted { get; set; }

    // relationship with Employees
    public ICollection<Book> Books { get; set; } = new List<Book>();

    // relationship with City
    public int CityId { get; set; }
    public City City { get; set; } = null!;
}
