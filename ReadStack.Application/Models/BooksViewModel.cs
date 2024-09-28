using ReadStack.Core.Entities;

namespace ReadStack.Application.Models;

public class BooksViewModel
{
    public BooksViewModel(string title, string author, int publishedYear, string genre)
    {
        Title = title;
        Author = author;
        PublishedYear = publishedYear;
        Genre = genre;
    }

    public string Title { get; private set; }
    public string Author { get; private set; }
    public int PublishedYear { get; private set; }
    public string Genre { get; private set; }

    public static BooksViewModel FromEntity(Book book)
    {
        return new BooksViewModel(book.Title, book.Author, book.PublishedYear, book.Genre);
    }
}