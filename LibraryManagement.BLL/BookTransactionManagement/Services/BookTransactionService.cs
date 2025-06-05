//using LibraryManagement.BLL.BookTransactionManagement.Dtos;
//using LibraryManagement.DAL.BookTransactionManagement.Repositories;
//using LibraryManagement.Models;

//namespace LibraryManagement.BLL.BookTransactionManagement.Services;

//public class BookTransactionService : IBookTransactionService
//{
//    private readonly IBookTransactionRepository _repo;

//    public BookTransactionService(IBookTransactionRepository repo)
//    {
//        _repo = repo;
//    }

//    public async Task<List<BookTransactionDto>> GetAllAsync(string? status, DateTime? borrowDate, DateTime? returnDate)
//    {
//        var data = await _repo.GetAllWithBooksAsync();

//        if (!string.IsNullOrWhiteSpace(status))
//        {
//            data = status == "borrowed"
//                ? data.Where(x => !x.IsReturned).ToList()
//                : data.Where(x => x.IsReturned).ToList();
//        }

//        if (borrowDate.HasValue)
//            data = data.Where(x => x.BorrowedDate.Date == borrowDate.Value.Date).ToList();

//        if (returnDate.HasValue)
//            data = data.Where(x => x.ReturnedDate.HasValue && x.ReturnedDate.Value.Date == returnDate.Value.Date).ToList();

//        return data.Select(x => new BookTransactionDto
//        {
//            Id = x.Id,
//            BookId = x.BookId,
//            BookTitle = x.Book.Title,
//            BorrowedDate = x.BorrowedDate,
//            ReturnedDate = x.ReturnedDate
//        }).ToList();
//    }

//    public async Task BorrowAsync(int bookId)
//    {
//        var latest = await _repo.GetLatestTransactionForBookAsync(bookId);

//        if (latest != null && !latest.IsReturned)
//            throw new InvalidOperationException("Book is already borrowed.");

//        var tx = new BookTransaction
//        {
//            BookId = bookId,
//            BorrowedDate = DateTime.Now
//        };

//        await _repo.AddAsync(tx);
//    }

//    public async Task ReturnAsync(int transactionId)
//    {
//        var tx = await _repo.GetByIdAsync(transactionId);
//        if (tx == null || tx.IsReturned)
//            throw new InvalidOperationException("Invalid return operation.");

//        await _repo.ReturnBookAsync(tx);
//    }
//}

using LibraryManagement.BLL.BookTransactionManagement.Dtos;
using LibraryManagement.DAL.BookTransactionManagement.Repositories;
using LibraryManagement.Models;

namespace LibraryManagement.BLL.BookTransactionManagement.Services;

public class BookTransactionService : IBookTransactionService
{
    private readonly IBookTransactionRepository _repo;

    public BookTransactionService(IBookTransactionRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<BookTransactionDto>> GetAllAsync(string? status, DateTime? borrowDate, DateTime? returnDate)
    {
        var data = await _repo.GetAllWithBooksAsync();

        if (!string.IsNullOrWhiteSpace(status))
        {
            data = status == "borrowed"
                ? data.Where(x => !x.IsReturned).ToList()
                : data.Where(x => x.IsReturned).ToList();
        }

        if (borrowDate.HasValue)
            data = data.Where(x => x.BorrowedDate.Date == borrowDate.Value.Date).ToList();

        if (returnDate.HasValue)
            data = data.Where(x => x.ReturnedDate.HasValue && x.ReturnedDate.Value.Date == returnDate.Value.Date).ToList();

        return data.Select(x => new BookTransactionDto
        {
            Id = x.Id,
            BookId = x.BookId,
            BookTitle = x.Book.Title,
            BorrowedDate = x.BorrowedDate,
            ReturnedDate = x.ReturnedDate
        }).ToList();
    }

    public async Task<BookTransactionDto?> GetTransactionByBookIdAsync(int bookId)
    {
        var latest = await _repo.GetLatestTransactionForBookAsync(bookId);
        if (latest == null) return null;

        return new BookTransactionDto
        {
            Id = latest.Id,
            BookId = latest.BookId,
            BookTitle = latest.Book.Title,
            BorrowedDate = latest.BorrowedDate,
            ReturnedDate = latest.ReturnedDate
        };
    }

    public async Task BorrowAsync(int bookId)
    {
        var latest = await _repo.GetLatestTransactionForBookAsync(bookId);

        if (latest != null && !latest.IsReturned)
            throw new InvalidOperationException("Book is already borrowed.");

        var tx = new BookTransaction
        {
            BookId = bookId,
            BorrowedDate = DateTime.Now
        };

        await _repo.AddAsync(tx);
    }

    public async Task ReturnAsync(int transactionId)
    {
        var tx = await _repo.GetByIdAsync(transactionId);
        if (tx == null || tx.IsReturned)
            throw new InvalidOperationException("Invalid return operation.");

        await _repo.ReturnBookAsync(tx);
    }
}
