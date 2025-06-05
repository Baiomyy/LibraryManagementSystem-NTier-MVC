using LibraryManagement.BLL.BookTransactionManagement.Dtos;
using LibraryManagement.Models;

namespace LibraryManagement.BLL.BookTransactionManagement.Services;

public interface IBookTransactionService
{
    Task<List<BookTransactionDto>> GetAllAsync(string? status, DateTime? borrowDate, DateTime? returnDate);

    Task<BookTransactionDto?> GetTransactionByBookIdAsync(int bookId);

    Task BorrowAsync(int bookId);

    Task ReturnAsync(int transactionId);
}