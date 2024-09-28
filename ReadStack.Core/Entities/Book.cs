namespace ReadStack.Core.Entities;

public class Book : BaseEntity
{
    public Book(string title, string author, int publishedYear, string genre)
    : base()
    {
        Title = title;
        Author = author;
        PublishedYear = publishedYear;
        Genre = genre;
        Loans = new List<Loan>();
    }

    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int PublishedYear { get; private set; }
    public string Genre { get; private set; }

    public List<Loan> Loans { get; private set; }

    public void Update(string title, string author, int publishedYear, string genre)
    {
        Title = title;
        Author = author;
        PublishedYear = publishedYear;
        Genre = genre;
    }
}