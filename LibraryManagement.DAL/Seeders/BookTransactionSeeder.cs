using LibraryManagement.DAL.Persistence;
using LibraryManagement.DAL.Seeders;
using LibraryManagement.Models;

public class BookTransactionSeeder : IDbSeeder
{
    public void Seed(LibraryDbContext context)
    {
        // Seed only if no transactions exist and at least two books exist
        if (!context.BookTransactions.Any() && context.Books.Count() >= 2)
        {
            var firstBook = context.Books.OrderBy(b => b.Id).First();
            var secondBook = context.Books.OrderBy(b => b.Id).Skip(1).First();

            context.BookTransactions.AddRange(
                new BookTransaction
                {
                    BookId = firstBook.Id,
                    BorrowedDate = DateTime.Now.AddDays(-10),
                    ReturnedDate = DateTime.Now.AddDays(-3)
                },
                new BookTransaction
                {
                    BookId = secondBook.Id,
                    BorrowedDate = DateTime.Now.AddDays(-5),
                    ReturnedDate = null // still borrowed
                }
            );
            context.SaveChanges();
        }
    }
}