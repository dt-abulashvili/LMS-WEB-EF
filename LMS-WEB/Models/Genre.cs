using LMS_WEB.Models.Interfaces;

namespace LMS_WEB.Models;

public class Genre : ISoftDeletable
{
    public int GenreID { get; set; }
    public string Name { get; set; } = null!;
    public bool IsDeleted { get; set; }

    // Oany-to-many
    public ICollection<Book> Books { get; set; } = new List<Book>();
}
