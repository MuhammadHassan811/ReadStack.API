using ReadStack.Core.Entities;

namespace ReadStack.Application.Models;

public class CreateBookInputModel
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublishedYear { get; set; }
    public string Genre { get; set; }

    public Book ToEntity()
        => new(Title, Author, PublishedYear, Genre);
}