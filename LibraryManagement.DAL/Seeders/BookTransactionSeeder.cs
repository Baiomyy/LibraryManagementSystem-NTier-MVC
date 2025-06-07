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
                new BookTransaction { BookId = 1, BorrowedDate = DateTime.Now.AddDays(-20), ReturnedDate = DateTime.Now.AddDays(-15) },
                new BookTransaction { BookId = 2, BorrowedDate = DateTime.Now.AddDays(-19), ReturnedDate = DateTime.Now.AddDays(-10) },
                new BookTransaction { BookId = 3, BorrowedDate = DateTime.Now.AddDays(-18), ReturnedDate = null },  // still borrowed
                new BookTransaction { BookId = 4, BorrowedDate = DateTime.Now.AddDays(-17), ReturnedDate = DateTime.Now.AddDays(-5) },
                new BookTransaction { BookId = 5, BorrowedDate = DateTime.Now.AddDays(-16), ReturnedDate = DateTime.Now.AddDays(-1) },
                new BookTransaction { BookId = 6, BorrowedDate = DateTime.Now.AddDays(-15), ReturnedDate = null }, // still borrowed
                new BookTransaction { BookId = 7, BorrowedDate = DateTime.Now.AddDays(-14), ReturnedDate = DateTime.Now.AddDays(-7) },
                new BookTransaction { BookId = 8, BorrowedDate = DateTime.Now.AddDays(-13), ReturnedDate = DateTime.Now.AddDays(-2) },
                new BookTransaction { BookId = 9, BorrowedDate = DateTime.Now.AddDays(-12), ReturnedDate = null }, // still borrowed
                new BookTransaction { BookId = 10, BorrowedDate = DateTime.Now.AddDays(-11), ReturnedDate = DateTime.Now.AddDays(-3) },

                new BookTransaction { BookId = 1, BorrowedDate = DateTime.Now.AddDays(-10), ReturnedDate = null }, // still borrowed
                new BookTransaction { BookId = 2, BorrowedDate = DateTime.Now.AddDays(-9), ReturnedDate = DateTime.Now.AddDays(-4) },
                new BookTransaction { BookId = 3, BorrowedDate = DateTime.Now.AddDays(-8), ReturnedDate = DateTime.Now.AddDays(-2) },
                new BookTransaction { BookId = 4, BorrowedDate = DateTime.Now.AddDays(-7), ReturnedDate = null }, // still borrowed
                new BookTransaction { BookId = 5, BorrowedDate = DateTime.Now.AddDays(-6), ReturnedDate = DateTime.Now.AddDays(-1) },
                new BookTransaction { BookId = 6, BorrowedDate = DateTime.Now.AddDays(-5), ReturnedDate = null }, // still borrowed
                new BookTransaction { BookId = 7, BorrowedDate = DateTime.Now.AddDays(-4), ReturnedDate = DateTime.Now.AddDays(-1) },
                new BookTransaction { BookId = 8, BorrowedDate = DateTime.Now.AddDays(-3), ReturnedDate = null }, // still borrowed
                new BookTransaction { BookId = 9, BorrowedDate = DateTime.Now.AddDays(-2), ReturnedDate = DateTime.Now.AddDays(-1) },
                new BookTransaction { BookId = 10, BorrowedDate = DateTime.Now.AddDays(-1), ReturnedDate = null }, // still borrowed

                new BookTransaction { BookId = 1, BorrowedDate = DateTime.Now.AddDays(-25), ReturnedDate = DateTime.Now.AddDays(-20) },
                new BookTransaction { BookId = 2, BorrowedDate = DateTime.Now.AddDays(-24), ReturnedDate = DateTime.Now.AddDays(-19) },
                new BookTransaction { BookId = 3, BorrowedDate = DateTime.Now.AddDays(-23), ReturnedDate = DateTime.Now.AddDays(-18) },
                new BookTransaction { BookId = 4, BorrowedDate = DateTime.Now.AddDays(-22), ReturnedDate = DateTime.Now.AddDays(-17) },
                new BookTransaction { BookId = 5, BorrowedDate = DateTime.Now.AddDays(-21), ReturnedDate = DateTime.Now.AddDays(-16) }
            );
            context.SaveChanges();
        }
    }
}