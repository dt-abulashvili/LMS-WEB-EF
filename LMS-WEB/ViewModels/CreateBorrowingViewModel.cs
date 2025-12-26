using LMS_WEB.Models;

namespace LMS_WEB.ViewModels;

public class CreateBorrowingViewModel
{
    public DateTime BorrowDate { get; set; }
    public DateTime ReturnDate { get; set; }

    public int CustomerId { get; set; }

    public List<int> SelectedBookIds { get; set; } = [];

    public IEnumerable<Customer> Customers { get; set; } = [];
    public IEnumerable<Book> Books { get; set; } = [];
}
