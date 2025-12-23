using LMS_WEB.Models;

namespace LMS_WEB.ViewModels;

public class ReferenceDataViewModel
{
    public IEnumerable<Country> Countries { get; set; } = new List<Country>();
    public IEnumerable<City> Cities { get; set; } = new List<City>();
    public IEnumerable<Nationality> Nationalities { get; set; } = new List<Nationality>();
    public IEnumerable<Publisher> Publishers { get; set; } = new List<Publisher>();
    public IEnumerable<Genre> Genres { get; set; } = new List<Genre>();
}
