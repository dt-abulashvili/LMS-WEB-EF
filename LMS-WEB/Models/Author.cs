namespace LMS_WEB.Models;

public class Author
{
    public int AuthorID { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;   
    public bool IsDeleted { get; set; }

    // Location
    public int NationalityID { get; set; }
    public Nationality Nationality { get; set; } = null!;

    public int CityID { get; set; }
    public City City { get; set; } = null!;

    //Many-to-many
    public ICollection<Book> Books { get; set; } = new List<Book>();

}
