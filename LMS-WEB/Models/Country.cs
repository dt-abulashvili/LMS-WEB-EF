namespace LMS_WEB.Models;

public class Country
{
    public int CountryID { get; set; }
    public string Name { get; set; } = null!;

    // Relationship with Cities
    public ICollection<City> Cities { get; set; } = new List<City>();   
}
