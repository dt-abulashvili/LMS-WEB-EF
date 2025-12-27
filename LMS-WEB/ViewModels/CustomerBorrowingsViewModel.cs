using LMS_WEB.Models;

namespace LMS_WEB.ViewModels;

public class CustomerBorrowingsViewModel
{
    public string CustomerName { get; set; } = null!;
    public IEnumerable<Borrowing> Borrowings { get; set; } = [];
    public IEnumerable<Subscription> Subscriptions { get; set; } = [];
}
