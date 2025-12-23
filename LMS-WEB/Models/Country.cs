using LMS_WEB.Models.Interfaces;

namespace LMS_WEB.Models;

public class Country : ISoftDeletable
{
    public int CountryID { get; set; }
    public string Name { get; set; } = null!;
    public bool IsDeleted { get; set; }

    // Relationship with Cities
    public ICollection<City> Cities { get; set; } = new List<City>();   
}
