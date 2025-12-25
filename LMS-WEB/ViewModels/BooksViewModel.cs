using LMS_WEB.Models;

namespace LMS_WEB.ViewModels;

public class BooksViewModel
{
    public IEnumerable<Book> Books { get; set; } = new List<Book>();
    public IEnumerable<Author> Authors { get; set; } = new List<Author>();
    public IEnumerable<Genre> Genres { get; set; } = new List<Genre>();
    public IEnumerable<Publisher> Publishers { get; set; } = new List<Publisher>();
}
