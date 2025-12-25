using LMS_WEB.Models;

namespace LMS_WEB.ViewModels;

public class CustomersViewModel
{
    public IEnumerable<Customer> Customers { get; set; } = new List<Customer>();
    public IEnumerable<City> Cities { get; set; } = new List<City>();
    public IEnumerable<Nationality> Nationalities { get; set; } = new List<Nationality>();
}
