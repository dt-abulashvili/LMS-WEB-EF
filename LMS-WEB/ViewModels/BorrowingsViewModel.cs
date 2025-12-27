using LMS_WEB.Models;

namespace LMS_WEB.ViewModels;

public class BorrowingsViewModel
{
    public IEnumerable<Borrowing> Borrowings { get; set; } = [];
    public IEnumerable<Customer> Customers { get; set; } = [];
    public IEnumerable<Subscription> Subscriptions { get; set; } = [];
}
