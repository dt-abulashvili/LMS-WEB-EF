using LMS_WEB.Models;

namespace LMS_WEB.ViewModels;

public class AuthorsViewModel
{
    public IEnumerable<Author> Authors { get; set; } = new List<Author>();
    public IEnumerable<City> Cities { get; set; } = new List<City>();
    public IEnumerable<Nationality> Nationalities { get; set; } = new List<Nationality>();
}
