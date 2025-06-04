using LibraryManagement.DAL.Persistence;
using LibraryManagement.DAL.Seeders;
using LibraryManagement.Models;

public class BookSeeder : IDbSeeder
{
    public void Seed(LibraryDbContext context)
    {
        if (!context.Books.Any() && context.Authors.Any())
        {
            var firstAuthor = context.Authors.First();

            context.Books.AddRange(
                new Book
                {
                    Title = "The Mysterious Island",
                    Genre = Genre.Adventure,
                    Description = "A thrilling journey on a remote island.",
                    AuthorId = firstAuthor.Id
                },
                new Book
                {
                    Title = "Love in Cairo",
                    Genre = Genre.Romance,
                    Description = "A heartwarming love story.",
                    AuthorId = firstAuthor.Id
                }
            );
            context.SaveChanges();
        }
    }
}
