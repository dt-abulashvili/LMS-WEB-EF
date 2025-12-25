using LMS_WEB.Models;

namespace LMS_WEB.ViewModels;

public class AuthorBooksViewModel
{
    public string AuthorName { get; set; } = null!;
    public IEnumerable<Book> Books { get; set; } = new List<Book>();
}

