using LMS_WEB.Models.Interfaces;

namespace LMS_WEB.Models;

public class City : ISoftDeletable
{
    public int CityID { get; set; }
    public string Name { get; set; } = null!;
    public bool IsDeleted { get; set; }

    // Country
    public int CountryID { get; set; }
    public Country Country { get; set; } = null!;

    // One-to-many
    public ICollection<Publisher> Publishers { get; set; } = new List<Publisher>();
    public ICollection<Author> Authors { get; set; } = new List<Author>();
    public ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
