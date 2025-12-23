using LMS_WEB.Models.Interfaces;

namespace LMS_WEB.Models;

public class Book : ISoftDeletable
{
    public int BookID { get; set; }
    public string Title { get; set; } = null!;
    public int PublishedYear { get; set; }
    public bool IsDeleted { get; set; }

    // Publisher
    public int PublisherId { get; set; }
    public Publisher Publisher { get; set; } = null!;

    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!;

    public int GenreId { get; set; }
    public Genre Genre { get; set; } = null!;

    // Many-to-many
    public ICollection<Borrowing> Borrowings { get; set; } = new List<Borrowing>();
}
