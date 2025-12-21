namespace LMS_WEB.Models;

public class Genre
{
    public int GenreID { get; set; }
    public string Name { get; set; } = null!;

    // Many-to-many
    public ICollection<Book> Books { get; set; } = new List<Book>();
}
