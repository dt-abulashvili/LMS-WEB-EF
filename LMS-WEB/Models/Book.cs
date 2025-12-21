using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_WEB.Models;

public class Book
{
    public int BookID { get; set; }
    public string Title { get; set; } = null!;
    public int PublishedYear { get; set; }
    public bool IsDeleted { get; set; }

    // Publisher
    public int PublisherId { get; set; }
    public Publisher Publisher { get; set; } = null!;

    // Many-to-many
    public ICollection<Author> Authors { get; set; } = new List<Author>();  
    public ICollection<Genre> Genres { get; set; } = new List<Genre>();
    public ICollection<Borrowing> Borrowings { get; set; } = new List<Borrowing>();
}
